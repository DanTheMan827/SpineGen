using SpineGen.Drawing;
using SpineGen.Interfaces;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SpineGen.DrawingBitmaps
{
    public class SystemDrawingBitmap : IBitmap<Bitmap>
    {
        private static Graphics GetGraphics(Bitmap bitmap) {
            var g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            return g;
        }

        public SystemDrawingBitmap(Bitmap image)
        {
            Bitmap = image;
        }

        public SystemDrawingBitmap(IBitmap bitmap)
        {
            if (bitmap is SystemDrawingBitmap)
            {
                Bitmap = (bitmap as SystemDrawingBitmap).Clone().Bitmap;
                return;
            }

            if (bitmap.PixelData.Length != (bitmap.Width * bitmap.Height))
                throw new FormatException("Length of PixelData is incorrect");

            Bitmap = new Bitmap(bitmap.Width, bitmap.Height);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Bitmap.SetPixel(x, y, bitmap.PixelData[x + (y * Bitmap.Width)]);
                }
            }
        }

        public int Width => Bitmap.Size.Width;

        public int Height => Bitmap.Size.Height;

        public Size Size => new Size(Width, Height);

        public Bitmap Bitmap { get; private set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Color[] PixelData
        {
            get
            {
                var pixelData = new Color[Bitmap.Width * Bitmap.Height];

                for (int y = 0; y < Bitmap.Height; y++)
                {
                    for (int x = 0; x < Bitmap.Width; x++)
                    {
                        pixelData[x + (y * Bitmap.Width)] = Bitmap.GetPixel(x, y);
                    }
                }

                return pixelData;
            }
        }

        public IBitmap<Bitmap> Crop(Rectangle rect)
        {
            var output = new Bitmap(rect.Width, rect.Height, Bitmap.PixelFormat);

            using (var g = GetGraphics(output))
            {
                g.DrawImage(Bitmap, new Rectangle(0, 0, rect.Width, rect.Height), rect, GraphicsUnit.Pixel);
            }

            Bitmap = output;

            return this;
        }

        public IBitmap<Bitmap> DrawImage(Bitmap image, Point destination)
        {
            using (var g = GetGraphics(Bitmap))
            {
                g.DrawImage(image, destination);
            }

            return this;
        }

        public bool EmptyColumn(int x) => Helpers.AllTransparentColumn(this, x);

        public bool EmptyRow(int y) => Helpers.AllTransparentRow(this, y);

        public Color GetPixel(int x, int y) => Bitmap.GetPixel(x, y);

        public IBitmap<Bitmap> ResizeToFit(Size size)
        {
            var newSize = Helpers.SizeToFit(Bitmap.Size, size);
            var output = new Bitmap(newSize.Width, newSize.Height, Bitmap.PixelFormat);

            using (var g = GetGraphics(output))
            {
                g.DrawImage(Bitmap, new Rectangle(Point.Empty, newSize), new Rectangle(Point.Empty, Bitmap.Size), GraphicsUnit.Pixel);
            }

            Bitmap = output;

            return this;
        }

        public IBitmap<Bitmap> Resize(Size size)
        {
            var output = new Bitmap(size.Width, size.Height, Bitmap.PixelFormat);

            using (var g = GetGraphics(output))
            {
                g.DrawImage(Bitmap, new Rectangle(Point.Empty, size), new Rectangle(Point.Empty, Bitmap.Size), GraphicsUnit.Pixel);
            }

            Bitmap = output;

            return this;
        }

        public IBitmap<Bitmap> Rotate(Rotation rotation)
        {
            if (rotation == Rotation.RotateNone)
                return this;

            var bitmap = Bitmap;

            switch (rotation)
            {
                case Rotation.Rotate90:
                    bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;

                case Rotation.Rotate180:
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;

                case Rotation.Rotate270:
                    bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
            }

            Bitmap = bitmap;

            return this;
        }

        public IBitmap<Bitmap> TrimPixels() => Crop(Helpers.GetNonTransparentRect(this));

        public IBitmap<Bitmap> Clone()
        {
            var output = new Bitmap(Width, Height, Bitmap.PixelFormat);
            using (var g = GetGraphics(output))
            {
                g.DrawImage(Bitmap, new Rectangle(Point.Empty, Bitmap.Size));
            }
            return new SystemDrawingBitmap(output);
        }
    }
}
