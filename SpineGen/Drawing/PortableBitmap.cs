using SpineGen.Interfaces;
using System;
using System.Diagnostics;
using System.Drawing;

namespace SpineGen.Drawing
{
    public class PortableBitmap : IBitmap<PortableBitmap>
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Color[] PixelData { get; private set; }

        public Size Size => new Size(Width, Height);

        public PortableBitmap Bitmap => throw new NotImplementedException();

        public PortableBitmap(IBitmap bitmap) : this(bitmap.PixelData, bitmap.Width, bitmap.Height) { }

        public PortableBitmap(Color[] pixelData, int width, int height)
        {
            PixelData = pixelData;
            Width = width;
            Height = height;
        }

        public IBitmap<PortableBitmap> Clone() => new PortableBitmap(PixelData.Clone() as Color[], Width, Height);
        public IBitmap<PortableBitmap> DrawImage(PortableBitmap image, Point destination) => throw new NotImplementedException();
        public IBitmap<PortableBitmap> Resize(Size size) => throw new NotImplementedException();
        public IBitmap<PortableBitmap> ResizeToFit(Size size) => throw new NotImplementedException();
        public IBitmap<PortableBitmap> Crop(Rectangle rect) => throw new NotImplementedException();
        public IBitmap<PortableBitmap> Rotate(Rotation rotation) => throw new NotImplementedException();
        public IBitmap<PortableBitmap> TrimPixels() => throw new NotImplementedException();
        public bool EmptyRow(int y) => throw new NotImplementedException();
        public bool EmptyColumn(int x) => throw new NotImplementedException();
        public Color GetPixel(int x, int y) => throw new NotImplementedException();
        public IBitmap<PortableBitmap> Extract(Rectangle rect) => throw new NotImplementedException();
        public IBitmap<PortableBitmap> ClearRegion(Rectangle rect) => throw new NotImplementedException();
    }
}
