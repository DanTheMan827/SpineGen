using SpineGen.Interfaces;
using System;
using System.Drawing;

namespace SpineGen.Drawing
{
    public static class Helpers
    {
        /// <summary>
        /// Calculates a new size to fit within the destination size while keeping the aspect ratio..
        /// </summary>
        /// <param name="currentSize">The current size.</param>
        /// <param name="destinationSize">The destination size bounds.</param>
        /// <returns></returns>
        public static Size SizeToFit(Size currentSize, Size destinationSize)
        {
            var width = (float)destinationSize.Width;
            var height = (float)destinationSize.Height;
            var xRatio = width / currentSize.Width;
            var yRatio = height / currentSize.Height;
            var ratio = Math.Min(xRatio, yRatio);
            return new Size(Math.Min(destinationSize.Width, (int)Math.Round(currentSize.Width * ratio, MidpointRounding.AwayFromZero)), Math.Min(destinationSize.Height, (int)Math.Round(currentSize.Height * ratio, MidpointRounding.AwayFromZero)));
        }

        public static bool AllTransparentRow(IBitmap bmp, int y)
        {
            for (int x = 0; x < bmp.Width; ++x)
                if (bmp.GetPixel(x, y).A != 0)
                    return false;
            return true;
        }

        public static bool AllTransparentColumn(IBitmap bmp, int x)
        {
            for (int y = 0; y < bmp.Height; ++y)
                if (bmp.GetPixel(x, y).A != 0)
                    return false;
            return true;
        }

        public static Rectangle GetNonTransparentRect(IBitmap bmp)
        {
            int w = bmp.Width;
            int h = bmp.Height;

            int topmost = 0;
            for (int row = 0; row < h; ++row)
            {
                if (!bmp.EmptyRow(row))
                    break;
                topmost = row;
            }

            int bottommost = 0;
            for (int row = h - 1; row >= 0; --row)
            {
                if (!bmp.EmptyRow(row))
                    break;
                bottommost = row;
            }

            int leftmost = 0, rightmost = 0;
            for (int col = 0; col < w; ++col)
            {
                if (!bmp.EmptyColumn(col))
                    break;
                leftmost = col;
            }

            for (int col = w - 1; col >= 0; --col)
            {
                if (!bmp.EmptyColumn(col))
                    break;
                rightmost = col;
            }

            if (rightmost == 0) rightmost = w; // As reached left
            if (bottommost == 0) bottommost = h; // As reached top.

            int croppedWidth = rightmost - leftmost;
            int croppedHeight = bottommost - topmost;

            if (croppedWidth == 0) // No border on left or right
            {
                leftmost = 0;
                croppedWidth = w;
            }

            if (croppedHeight == 0) // No border on top or bottom
            {
                topmost = 0;
                croppedHeight = h;
            }

            try
            {
                return new Rectangle(leftmost, topmost, croppedWidth, croppedHeight);
            }
            catch (Exception ex)
            {
                throw new Exception(
                  string.Format("Values are topmost={0} btm={1} left={2} right={3} croppedWidth={4} croppedHeight={5}", topmost, bottommost, leftmost, rightmost, croppedWidth, croppedHeight),
                  ex);
            }
        }
    }
}
