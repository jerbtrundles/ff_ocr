using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Graphics.Imaging;
using Windows.Media.Ocr;
using Windows.Storage;
using Windows.Storage.Streams;

namespace ff_ocr {
    class DataCaptureArgs {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private int _frameX;
        private int _frameY;
        private static int _dataClearThreshold = 20;
        public bool IsStale { get => _noDataCount > _dataClearThreshold; }

        private SoftwareBitmap _sb;
        private Bitmap _bmp;
        private PictureBox _pb;
        private Label _lblStatus;

        private string _tempCapturePath;
        private int _noDataCount;

        private OcrResult _lastResult;
        public OcrResult LastResult { get => _lastResult; }

        public DataCaptureArgs(string id, int x, int y, int width, int height, PictureBox pb, Label lblStatus) {
            Set(x, y, width, height);
            _pb = pb;
            _lblStatus = lblStatus;
            _tempCapturePath = Path.Combine(Paths.Desktop, id + "_temp.bmp");
        }

        public void Set(int x, int y, int width, int height) {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            _bmp = new Bitmap(Width, Height);
        }

        public async Task Capture(OcrEngine ocr) {
            _frameX = ++_frameX % 5;
            _frameY = ++_frameY % 6;

            using (Graphics g = Graphics.FromImage(_bmp)) {
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X + X + _frameX, Screen.PrimaryScreen.Bounds.Y + Y + _frameY, 0, 0, _bmp.Size, CopyPixelOperation.SourceCopy);
            }

            _bmp.Save(_tempCapturePath);
            _pb.Image = _bmp;

            StorageFile input = await StorageFile.GetFileFromPathAsync(_tempCapturePath);
            using (IRandomAccessStream stream = await input.OpenAsync(FileAccessMode.Read)) {
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                _sb = await decoder.GetSoftwareBitmapAsync();
            }

            _lastResult = await ocr.RecognizeAsync(_sb);

            if (_lastResult.Lines.Count == 0) {
                ++_noDataCount;
            }
            else {
                _noDataCount = 0;
            }
        }

        public void Cleanup() {
            if (File.Exists(_tempCapturePath)) { File.Delete(_tempCapturePath); }
        }
    }
}
