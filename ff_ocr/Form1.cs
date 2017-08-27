using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Windows.Graphics.Imaging;
using Windows.Media.Ocr;
using Windows.Storage;
using Windows.Storage.Streams;

namespace ff_ocr {
    public partial class Form1 : Form {
        OcrEngine ocr;
        bool bEnemyCaptureReady = true;
        bool bItemCaptureReady = false;

        List<Enemy> Enemies = new List<Enemy>();
        static string enemiesSourcePath = Path.Combine(Paths.Desktop, "enemies.xml");

        Enemy enemy1;
        Enemy enemy2;
        Enemy enemy3;
        Item item;

        DataCapture enemyData;
        DataCapture itemData;

        Regex regexEnemy = new Regex("[^a-zA-Z]");
        Regex regexItem = new Regex("[^a-zA-Z0-9]");

        #region Load
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            ocr = OcrEngine.TryCreateFromUserProfileLanguages();

            LoadEnemies();

            int enemyCaptureX = 395;
            int enemyCaptureY = 690;
            int enemyCaptureWidth = 360;
            int enemyCaptureHeight = 210;
            txtEnemyCaptureX.Text = enemyCaptureX.ToString();
            txtEnemyCaptureY.Text = enemyCaptureY.ToString();
            txtEnemyCaptureWidth.Text = enemyCaptureWidth.ToString();
            txtEnemyCaptureHeight.Text = enemyCaptureHeight.ToString();
            enemyData = new DataCapture("enemy", enemyCaptureX, enemyCaptureY, enemyCaptureWidth, enemyCaptureHeight, pbEnemyCapture, lblEnemyCaptureStatus);

            int itemCaptureX = 450;
            int itemCaptureY = 110;
            int itemCaptureWidth = 600;
            int itemCaptureHeight = 210;
            txtItemCaptureX.Text = itemCaptureX.ToString();
            txtItemCaptureY.Text = itemCaptureY.ToString();
            txtItemCaptureWidth.Text = itemCaptureWidth.ToString();
            txtItemCaptureHeight.Text = itemCaptureHeight.ToString();
            itemData = new DataCapture("item", itemCaptureX, itemCaptureY, itemCaptureWidth, itemCaptureHeight, pbItemCapture, lblItemCaptureStatus);

            //LoadExtraData();

            //XDocument doc = XDocument.Load(@"ffiv_enemies.xml");
            //foreach (XElement eTable in doc.Root.Elements("table")) {
            //    Enemy enemy = new Enemy(eTable);
            //    Enemies.Add(enemy);
            //}
        }
        private void LoadEnemies() {
            XDocument doc = XDocument.Load(@"enemies.xml");
            Enemies = doc.Root.Elements("enemy").Select(x => new Enemy(x)).ToList();
        }
        #endregion

        #region Enemy
        private async Task CaptureEnemyData() {
            Stopwatch s = Stopwatch.StartNew();

            await enemyData.Capture(ocr);
            if (enemyData.LastResult.Lines.Count == 0) {
                AppendEnemyCaptureString("(nothing)");

                if (enemyData.IsStale) {
                    ClearEnemyUI();
                }
            }
            else {
                // grab text from OcrLines
                IEnumerable<string> lines = enemyData.LastResult.Lines
                    .Select(x => regexEnemy.Replace(x.Text.ToLower().Trim(), ""))
                    .Where(x => x.Length > 0 && !x.Contains("forwar")); // filter out fast forwards

                foreach (string line in lines) {
                    AppendEnemyCaptureString(line);

                    Enemy enemy = Enemies.Find(x => x.MatchStrings.Contains(line));
                    if (enemy != null) {

                        // edge cases (ghost/ghast, milon battle, ghost battle)
                        if (enemy.Name == "Milon" &&
                            ((enemy1 != null && enemy1.Name == "Milon Z.")
                             || (enemy2 != null && enemy2.Name == "Milon Z.")
                             || (enemy3 != null && enemy3.Name == "Milon Z."))) { continue; }

                        if (enemy == enemy1) { continue; }
                        if (enemy == enemy2) { continue; }
                        if (enemy == enemy3) { continue; }

                        if (pbEnemy1.Image == null) {
                            enemy1 = enemy;
                            SetEnemy(enemy, pbEnemy1, txtEnemy1);
                        }
                        else if (pbEnemy2.Image == null) {
                            enemy2 = enemy;
                            SetEnemy(enemy, pbEnemy2, txtEnemy2);
                        }
                        else if (pbEnemy3.Image == null) {
                            enemy3 = enemy;
                            SetEnemy(enemy, pbEnemy3, txtEnemy3);
                        }
                    }
                }
            }

            s.Stop();
            lblEnemyCaptureTime.Text = s.ElapsedMilliseconds.ToString() + " ms";
        }
        private void ClearEnemyUI() {
            pbEnemy1.Image = null;
            txtEnemy1.Clear();
            pbEnemy2.Image = null;
            txtEnemy2.Clear();
            pbEnemy3.Image = null;
            txtEnemy3.Clear();

            enemy1 = null;
            enemy2 = null;
            enemy3 = null;

            txtEnemyCaptureUnique.Clear();
        }
        private void SetEnemy(Enemy enemy, PictureBox pb, RichTextBox rtb) {
            pb.Image = Image.FromFile(enemy.ImagePath);
            rtb.Text = enemy.FullString;
        }
        private bool ValidateEnemyCaptureData() {
            if (!int.TryParse(txtEnemyCaptureX.Text, out int newX)) { return false; }
            if (!int.TryParse(txtEnemyCaptureY.Text, out int newY)) { return false; }
            if (!int.TryParse(txtEnemyCaptureWidth.Text, out int newWidth)) { return false; }
            if (!int.TryParse(txtEnemyCaptureHeight.Text, out int newHeight)) { return false; }
            if (newX < 10 || newX > 1000) { return false; }
            if (newY < 10 || newY > 1000) { return false; }
            if (newWidth < 10 || newWidth > 1000) { return false; }
            if (newHeight < 10 || newHeight > 1000) { return false; }
            return true;
        }
        private void btnSetEnemyCaptureData_Click(object sender, EventArgs e) {
            if (ValidateEnemyCaptureData()) {
                enemyData.Set(int.Parse(txtEnemyCaptureX.Text), int.Parse(txtEnemyCaptureY.Text), int.Parse(txtEnemyCaptureWidth.Text), int.Parse(txtEnemyCaptureHeight.Text));
                lblEnemyCaptureStatus.Text = "Data set.";
            }
            else {
                lblEnemyCaptureStatus.Text = "Invalid input.";
            }

            timerClearEnemyCaptureStatus.Enabled = true;
        }
        private void AppendEnemyCaptureString(string str) {
            if (txtEnemyCaptureLast15.Text.Length > 0 && txtEnemyCaptureLast15.Lines.Length > 15) {
                txtEnemyCaptureLast15.Text = txtEnemyCaptureLast15.Text.Substring(txtEnemyCaptureLast15.Text.IndexOf('\n') + 1);
            }
            txtEnemyCaptureLast15.AppendText(str + "\r\n");

            string[] lines = txtEnemyCaptureUnique.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines) {
                if (line == str) {
                    return;
                }
            }

            txtEnemyCaptureUnique.AppendText(str + "\r\n");
        }
        private void timerClearEnemyCaptureStatus_Tick(object sender, EventArgs e) {
            lblEnemyCaptureStatus.Text = string.Empty;
            timerClearEnemyCaptureStatus.Enabled = false;
        }
        private void btnEnemyAddManualString_Click(object sender, EventArgs e) {
            timerClearEnemyAddManualStringStatus.Enabled = false;
            string[] split = txtEnemyAddManualString.Text.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (split.Length != 2) {
                lblEnemyAddManualStringStatus.Text = "Invalid string format.";
            }
            else {
                Enemy enemy = Enemies.Find(x => x.Name.ToLower() == split[0].ToLower());
                if (enemy != null) {
                    enemy.MatchStrings.Add(split[1].ToLower());
                    lblEnemyAddManualStringStatus.Text = "String successfully added.";
                }
                else {
                    lblEnemyAddManualStringStatus.Text = "Enemy not found.";
                }
            }

            timerClearEnemyAddManualStringStatus.Enabled = true;
        }
        private void timerClearAddManualStringStatus_Tick(object sender, EventArgs e) {
            lblEnemyAddManualStringStatus.Text = "";
            timerClearEnemyAddManualStringStatus.Enabled = false;
        }
        private void btnClearEnemyCaptureUnique_Click(object sender, EventArgs e) {
            txtEnemyCaptureUnique.Clear();
            ClearEnemyUI();
        }
        private async void timerCaptureEnemyData_Tick(object sender, EventArgs e) {
            if (!bEnemyCaptureReady) { return; }
            bEnemyCaptureReady = false;
            await CaptureEnemyData();
            bItemCaptureReady = true;
        }
        #endregion

        #region Item
        private async Task CaptureItemData() {
            Stopwatch s = Stopwatch.StartNew();

            await itemData.Capture(ocr);
            if (itemData.LastResult.Lines.Count == 0) {
                AppendItemCaptureString("(nothing)");

                if (itemData.IsStale) {
                    ClearItemUI();
                }
            }
            else {
                IEnumerable<string> lines = itemData.LastResult.Lines.Select(x => regexItem.Replace(x.Text.ToLower().Trim(), "")).Where(x => x.Length > 0);
                foreach (string line in lines) {
                    AppendItemCaptureString(line);

                    //Enemy enemy = Enemies.Find(x => x.MatchStrings.Contains(name));
                    //if (enemy != null) {
                    //    if (enemy == enemy1) { continue; }
                    //    if (enemy == enemy2) { continue; }
                    //    if (enemy == enemy3) { continue; }

                    //    if (pbEnemy1.Image == null) {
                    //        enemy1 = enemy;
                    //        SetEnemy(enemy, pbEnemy1, txtEnemy1);
                    //    }
                    //    else if (pbEnemy2.Image == null) {
                    //        enemy2 = enemy;
                    //        SetEnemy(enemy, pbEnemy2, txtEnemy2);
                    //    }
                    //    else if (pbEnemy3.Image == null) {
                    //        enemy3 = enemy;
                    //        SetEnemy(enemy, pbEnemy3, txtEnemy3);
                    //    }
                    //}
                }
            }

            s.Stop();
            lblItemCaptureTime.Text = s.ElapsedMilliseconds.ToString() + " ms";
        }
        private void btnItemCaptureSetData_Click(object sender, EventArgs e) {
            if (ValidateItemCaptureData()) {
                itemData.Set(int.Parse(txtItemCaptureX.Text), int.Parse(txtItemCaptureY.Text), int.Parse(txtItemCaptureWidth.Text), int.Parse(txtItemCaptureHeight.Text));
                lblItemCaptureStatus.Text = "Data set.";
            }
            else {
                lblItemCaptureStatus.Text = "Invalid input.";
            }

            timerClearItemCaptureStatus.Enabled = true;
        }
        private bool ValidateItemCaptureData() {
            if (!int.TryParse(txtItemCaptureX.Text, out int newX)) { return false; }
            if (!int.TryParse(txtItemCaptureY.Text, out int newY)) { return false; }
            if (!int.TryParse(txtItemCaptureWidth.Text, out int newWidth)) { return false; }
            if (!int.TryParse(txtItemCaptureHeight.Text, out int newHeight)) { return false; }
            if (newX < 10 || newX > 1000) { return false; }
            if (newY < 10 || newY > 1000) { return false; }
            if (newWidth < 10 || newWidth > 1000) { return false; }
            if (newHeight < 10 || newHeight > 1000) { return false; }
            return true;
        }
        private void ClearItemUI() {
            txtItemCaptureUnique.Clear();
        }
        private void AppendItemCaptureString(string str) {
            if (txtItemCaptureLast15.Text.Length > 0 && txtItemCaptureLast15.Lines.Length > 15) {
                txtItemCaptureLast15.Text = txtItemCaptureLast15.Text.Substring(txtItemCaptureLast15.Text.IndexOf('\n') + 1);
            }
            txtItemCaptureLast15.AppendText(str + "\r\n");

            string[] lines = txtItemCaptureUnique.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines) {
                if (line == str) {
                    return;
                }
            }

            txtItemCaptureUnique.AppendText(str + "\r\n");
        }
        private void btnClearItemCaptureUnique_Click(object sender, EventArgs e) {
            txtItemCaptureUnique.Clear();
        }
        private async void timerCaptureItemData_Tick(object sender, EventArgs e) {
            if (!bItemCaptureReady) { return; }
            bItemCaptureReady = false;
            await CaptureItemData();
            bEnemyCaptureReady = true;
        }
        private void timerClearItemCaptureStatus_Tick(object sender, EventArgs e) {
            lblItemCaptureStatus.Text = string.Empty;
            timerClearItemCaptureStatus.Enabled = false;
        }
        #endregion

        #region Cleanup
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            enemyData.Cleanup();
            itemData.Cleanup();
            // if (File.Exists(tempItem)) { File.Delete(tempItem); }
            SaveEnemies();
        }
        private void SaveEnemies() {
            XElement eOutput = new XElement("enemies", Enemies.Select(x => x.ToElement()));
            eOutput.Save(enemiesSourcePath);
        }
        #endregion

        #region Miscellaneous Handlers
        private void txtNumeric_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }
        #endregion
    }
}


//Stopwatch s = Stopwatch.StartNew();
//OcrResult result = await enemyData.Recognize(ocr);



//s.Stop();
//            lblEnemyCaptureTime.Text = s.ElapsedMilliseconds.ToString() + " ms";


//private void LoadExtraData() {
//    List<string> matches = new List<string>();
//    List<string> nonMatches = new List<string>();

//    string path = @"extra_data.txt";
//    string[] lines = File.ReadAllLines(path);
//    foreach (string line in lines) {
//        if (line.StartsWith("*") || line.StartsWith("=")) { continue; }
//        string[] tokens = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
//        int i = 1;

//        StringBuilder sb = new StringBuilder(tokens[0]);
//        while (i < tokens.Length && char.IsLetter(tokens[i][0])) {
//            sb.Append(" " + tokens[i++]);
//        }
//        string name = sb.ToString();

//        Enemy e = Enemies.Find(x => x.Name.ToLower().Replace(" ", "").Replace(".", "").Replace("-", "") == name.ToLower().Replace(" ", "").Replace(".", "").Replace("-", ""));
//        if (e != null) {
//            // match
//            // matches.Add(name);
//            e.HP2 = tokens[i];
//            e.Experience2 = tokens[++i];
//            e.GP2 = tokens[++i];
//        }
//        //else {
//        //    // no match
//        //    nonMatches.Add(name);
//        //}
//    }

//    //List<Enemy> n = Enemies.Where(x => matches.Find(y => x.Name.ToLower().Replace(" ", "").Replace(".", "").Replace("-", "") == y.ToLower().Replace(" ", "").Replace(".", "").Replace("-", "")) == null).ToList();

//    //int j = 0;
//}

//private void DownloadImages() {
//    Directory.CreateDirectory("images");
//    using (WebClient client = new WebClient()) {
//        foreach (Enemy e in Enemies) {
//            client.DownloadFile(new Uri(e.ImageURL), Path.Combine("images", e.ImageURLStem));                    
//        }
//    }
//}


