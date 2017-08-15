using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Graphics.Imaging;
using Windows.Media.Ocr;
using Windows.Storage;
using Windows.Storage.Streams;

namespace ff_ocr {
    public partial class Form1 : Form {
        OcrEngine ocr;
        SoftwareBitmap bitmap;
        Bitmap bmp;

        public Form1() {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e) {
            ocr = OcrEngine.TryCreateFromUserProfileLanguages();
            bmp = new Bitmap(256, 256);
        }

        private async void button1_Click(object sender, EventArgs e) {
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            }

            pictureBox1.Image = bmp;
            string path = @"c:\users\baxte\desktop\temp.bmp";
            bmp.Save(path);
            await Recognize(path);
        }

        private async Task Recognize(string path) {
            StorageFile input = await StorageFile.GetFileFromPathAsync(path);
            using (IRandomAccessStream stream = await input.OpenAsync(FileAccessMode.Read)) {
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                bitmap = await decoder.GetSoftwareBitmapAsync();
            }

            OcrResult result = await ocr.RecognizeAsync(bitmap);
            foreach (OcrLine line in result.Lines) {
                richTextBox1.AppendText(line.Text + "\r\n");
            }
        }
    }
}
