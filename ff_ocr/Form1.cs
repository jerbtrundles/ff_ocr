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
        SoftwareBitmap bitmap;
        Bitmap bmp;
        bool bReady = true;
        List<Enemy> Enemies = new List<Enemy>();

        // file paths
        static string profile = "baxte";
        static string desktop = Path.Combine(@"c:\users\", profile, "desktop");
        static string temp = Path.Combine(desktop, "temp.bmp");
        static string enemies = Path.Combine(desktop, "enemies.xml");

        Enemy enemy1;
        Enemy enemy2;
        Enemy enemy3;

        int x = 395;
        int y = 690;
        int width = 360;
        int height = 210;
        int frameX = 0;
        int frameY = 0;
        int dataClearThreshold = 20;

        char[] filters = { ' ', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        int noBattleCount = 0;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            ocr = OcrEngine.TryCreateFromUserProfileLanguages();

            txtCaptureX.Text = x.ToString();
            txtCaptureY.Text = y.ToString();
            txtCaptureWidth.Text = width.ToString();
            txtCaptureHeight.Text = height.ToString();
            bmp = new Bitmap(width, height);

            XDocument doc = XDocument.Load(@"enemies.xml");
            Enemies = doc.Root.Elements("enemy").Select(x => new Enemy(x)).ToList();

            //LoadExtraData();

            //XDocument doc = XDocument.Load(@"ffiv_enemies.xml");
            //foreach (XElement eTable in doc.Root.Elements("table")) {
            //    Enemy enemy = new Enemy(eTable);
            //    Enemies.Add(enemy);
            //}
        }

        private async Task Recognize() {
            frameX = (frameX + 1) % 5;
            frameY = (frameY + 1) % 6;

            Stopwatch s = Stopwatch.StartNew();

            using (Graphics g = Graphics.FromImage(bmp)) {
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X + x + frameX, Screen.PrimaryScreen.Bounds.Y + y + frameY, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            }

            bmp.Save(temp);
            pbCapture.Image = bmp;

            StorageFile input = await StorageFile.GetFileFromPathAsync(temp);
            using (IRandomAccessStream stream = await input.OpenAsync(FileAccessMode.Read)) {
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                bitmap = await decoder.GetSoftwareBitmapAsync();
            }

            OcrResult result = await ocr.RecognizeAsync(bitmap);
            if (result.Lines.Count == 0) {
                Append("(nothing)");

                if (++noBattleCount == dataClearThreshold) {
                    ClearEnemyData();
                }
            }
            else {
                StringBuilder sb = new StringBuilder();
                noBattleCount = 0;
                foreach (OcrLine l in result.Lines) {
                    sb.AppendLine(l.Text);
                    string name = String.Join("", l.Text.ToLower().Trim().Split(filters, StringSplitOptions.RemoveEmptyEntries));
                    if (name.Length > 0) {
                        Append(name);
                        Enemy enemy = Enemies.Find(x => x.MatchStrings.Contains(name));
                        if (enemy != null) {
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
                //richTextBox1.Text = sb.ToString() + Environment.NewLine;
            }

            s.Stop();
            txtTime.Text = "Time: " + s.ElapsedMilliseconds.ToString() + " ms";
        }

        private void Append(string str) {
            if (richTextBox1.Lines.Length > 20) {
                richTextBox1.Text = richTextBox1.Text.Substring(richTextBox1.Text.IndexOf('\n') + 1);
            }
            richTextBox1.AppendText(str + "\r\n");

            string[] lines = txtUniqueStrings.Text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines) {
                if (line == str) {
                    return;
                }
            }

            txtUniqueStrings.AppendText(str + "\r\n");
        }

        private async void timerRecognize_Tick(object sender, EventArgs e) {
            if (!bReady) { return; }

            bReady = false;
            await Recognize();
            bReady = true;
        }

        private void ClearEnemyData() {
            pbEnemy1.Image = null;
            txtEnemy1.Clear();
            pbEnemy2.Image = null;
            txtEnemy2.Clear();
            pbEnemy3.Image = null;
            txtEnemy3.Clear();

            enemy1 = null;
            enemy2 = null;
            enemy3 = null;

            txtUniqueStrings.Clear();
        }

        private void SetEnemy(Enemy enemy, PictureBox pb, RichTextBox rtb) {
            pb.Image = Image.FromFile(enemy.ImagePath);
            rtb.Text = enemy.FullString;
        }

        private void btnSetCaptureData_Click(object sender, EventArgs e) {
            if (ValidateCaptureData()) {
                x = int.Parse(txtCaptureX.Text);
                y = int.Parse(txtCaptureY.Text);
                width = int.Parse(txtCaptureWidth.Text);
                height = int.Parse(txtCaptureHeight.Text);
                bmp = new Bitmap(width, height);
                lblCaptureStatus.Text = "Capture data successfully set.";

                // timer to clear status text
                timerClearCaptureStatus.Enabled = true;
            }
        }

        private void txtNumeric_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }

        private void timerClearCaptureStatus_Tick(object sender, EventArgs e) {
            lblCaptureStatus.Text = string.Empty;
            timerClearCaptureStatus.Enabled = false;
        }

        private bool ValidateCaptureData() {
            if (!int.TryParse(txtCaptureX.Text, out int newX)) {
                lblCaptureStatus.Text = "Error: X value is not a number.";
                return false;
            }

            if (!int.TryParse(txtCaptureY.Text, out int newY)) {
                lblCaptureStatus.Text = "Error: Y value is not a number.";
                return false;
            }

            if (!int.TryParse(txtCaptureWidth.Text, out int newWidth)) {
                lblCaptureStatus.Text = "Error: Width value is not a number.";
                return false;
            }

            if (!int.TryParse(txtCaptureHeight.Text, out int newHeight)) {
                lblCaptureStatus.Text = "Error: Height value is not a number.";
                return false;
            }

            if (newX < 10 || newX > 1000) {
                lblCaptureStatus.Text = "Error: X value must be between 10 and 1000.";
                return false;
            }

            if (newY < 10 || newY > 1000) {
                lblCaptureStatus.Text = "Error: Y value must be between 10 and 1000.";
                return false;
            }

            if (newWidth < 10 || newWidth > 1000) {
                lblCaptureStatus.Text = "Error: Width value must be between 10 and 1000.";
                return false;
            }

            if (newHeight < 10 || newHeight > 1000) {
                lblCaptureStatus.Text = "Error: Height value must be between 10 and 1000.";
                return false;
            }

            return true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            if (File.Exists(temp)) { File.Delete(temp); }
            SaveEnemies();
        }

        private void SaveEnemies() {
            XElement eOutput = new XElement("enemies", Enemies.Select(x => x.ToElement()));
            eOutput.Save(enemies);
        }

        private void btnAddManualString_Click(object sender, EventArgs e) {
            timerClearAddManualStringStatus.Enabled = false;
            string[] split = txtAddManualString.Text.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (split.Length != 2) {
                lblAddManualStringStatus.Text = "Invalid string format.";
            }
            else {
                Enemy enemy = Enemies.Find(x => x.Name.ToLower() == split[0].ToLower());
                if (enemy != null) {
                    enemy.MatchStrings.Add(split[1].ToLower());
                    lblAddManualStringStatus.Text = "String successfully added.";
                }
                else {
                    lblAddManualStringStatus.Text = "Enemy not found.";
                }
            }

            timerClearAddManualStringStatus.Enabled = true;
        }

        private void timerClearAddManualStringStatus_Tick(object sender, EventArgs e) {
            lblAddManualStringStatus.Text = "";
            timerClearAddManualStringStatus.Enabled = false;
        }

        private void btnClearUniqueStrings_Click(object sender, EventArgs e) {
            txtUniqueStrings.Clear();
        }
    }
}

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
