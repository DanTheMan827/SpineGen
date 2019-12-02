using SpineGen.Drawing;
using System.Drawing;

namespace SpineGen.Interfaces
{
    public interface IBitmap
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
        IBitmap<T> Resize(Size size);
        IBitmap<T> ResizeToFit(Size size);
        IBitmap<T> Crop(Rectangle rect);
        IBitmap<T> Rotate(Rotation rotation);
        IBitmap<T> TrimPixels();

    }
}
