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

        Enemy enemy1;
        Enemy enemy2;
        Enemy enemy3;

        int width = 389;
        int height = 292;
        int x = 423;
        int y = 709;
        char[] filters = { ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        int noBattleCount = 0;

        public Form1() {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e) {
            ocr = OcrEngine.TryCreateFromUserProfileLanguages();
            bmp = new Bitmap(width, height);

            XDocument doc = XDocument.Load(@"ffiv_enemies.xml");
            foreach (XElement eTable in doc.Root.Elements("table")) {
                Enemy enemy = new Enemy(eTable);
                Enemies.Add(enemy);
            }
        }

        private async Task Recognize() {
            string path = @"c:\users\baxte\desktop\temp.bmp";
            Stopwatch s = Stopwatch.StartNew();

            using (Graphics g = Graphics.FromImage(bmp)) {
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X + x, Screen.PrimaryScreen.Bounds.Y + y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            }

            bmp.Save(path);

            StorageFile input = await StorageFile.GetFileFromPathAsync(path);
            using (IRandomAccessStream stream = await input.OpenAsync(FileAccessMode.Read)) {
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                bitmap = await decoder.GetSoftwareBitmapAsync();
            }

            OcrResult result = await ocr.RecognizeAsync(bitmap);
            if (result.Lines.Count == 0) {
                richTextBox1.Clear();

                if (++noBattleCount == 3) {
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
                        richTextBox1.AppendText(name + "\r\n");
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
                richTextBox1.Text = sb.ToString() + Environment.NewLine;
            }

            s.Stop();
            richTextBox1.AppendText("Time: " + s.ElapsedMilliseconds.ToString() + " ms\r\n");
        }

        private async void timer1_Tick(object sender, EventArgs e) {
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
        }

        private void SetEnemy(Enemy enemy, PictureBox pb, RichTextBox rtb) {
            pb.Image = Image.FromFile(enemy.ImagePath);
            rtb.Text = enemy.FullString;
        }

        //private void DownloadImages() {
        //    Directory.CreateDirectory("images");
        //    using (WebClient client = new WebClient()) {
        //        foreach (Enemy e in Enemies) {
        //            client.DownloadFile(new Uri(e.ImageURL), Path.Combine("images", e.ImageURLStem));                    
        //        }
        //    }
        //}
    }
}
