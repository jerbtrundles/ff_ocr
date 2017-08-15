using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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

        int width = 389;
        int height = 292;
        int x = 433;
        int y = 719;
        char[] filters = { ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public Form1() {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e) {
            ocr = OcrEngine.TryCreateFromUserProfileLanguages();
            bmp = new Bitmap(width, height);

            XDocument doc = XDocument.Load(@"c:\users\joshbax\desktop\tables.xml");
            foreach (XElement eTable in doc.Root.Elements("table")) {
                Enemy enemy = new Enemy(eTable);
                Enemies.Add(enemy);
                listBox1.Items.Add(enemy);
            }
        }

        private async Task Recognize() {
            string path = @"c:\users\joshbax\desktop\temp.bmp";
            Stopwatch s = Stopwatch.StartNew();
            richTextBox1.Clear();

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
            foreach (OcrLine line in result.Lines) {
                richTextBox1.AppendText(String.Join("", line.Text.Split(filters, StringSplitOptions.RemoveEmptyEntries)) + "\r\n");
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (listBox1.SelectedIndex == -1) { return; }

            Enemy enemy = (Enemy)listBox1.SelectedItem;
            txtName.Text = enemy.Name;
            txtLevel.Text = enemy.Level;
            txtHP.Text = enemy.HP;
            txtAttack.Text = enemy.Attack;
            txtHitPercentage.Text = enemy.HitPercentage;
            txtMagicAttack.Text = enemy.MagicAttack;
            txtSpeed.Text = enemy.Speed;
            txtDefense.Text = enemy.Defense;
            txtEvasion.Text = enemy.Evasion;
            txtMagicDefense.Text = enemy.MagicDefense;
            txtMagicEvasion.Text = enemy.MagicEvasion;
            txtGP.Text = enemy.GP;
            txtExperience.Text = enemy.Experience;
            txtWeaknesses.Text = enemy.Weaknesses;
            txtAbsorbs.Text = enemy.Absorbs;
            txtResists.Text = enemy.Resists;

            pictureBox1.Load(enemy.ImageURL);
        }
    }
}
