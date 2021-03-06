﻿using SpineGen.Drawing;
using System;
using System.Drawing;

namespace SpineGen.Interfaces
{
    public interface IBitmap: IDisposable
    {
        int Width { get; }
        int Height { get; }
        Size Size { get; }
        Color[] PixelData { get; }
        bool EmptyRow(int y);
        bool EmptyColumn(int x);
        Color GetPixel(int x, int y);
    }
    public interface IBitmap<T>: IBitmap
    {
        T Bitmap { get; }
        IBitmap<T> Clone();
        IBitmap<T> DrawImage(T image, Point destination);
        IBitmap<T> Resize(Size size, bool enlarge);
        IBitmap<T> ResizeToFit(Size size, bool enlarge);
        IBitmap<T> Crop(Rectangle rect);
        IBitmap<T> Extract(Rectangle rect);
        IBitmap<T> ClearRegion(Rectangle rect);
        IBitmap<T> Rotate(Rotation rotation);
        IBitmap<T> TrimPixels();

    }
}
