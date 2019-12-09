using SpineGen.Drawing;
using SpineGen.Interfaces;
using System;
using System.Drawing;

namespace SpineGen
{
    public class Spine
    {
        public class Template<I>: IDisposable
        {
            public virtual IBitmap<I> Image { get; set; }
            public virtual Rotation LogoRotation { get; set; } = Rotation.RotateNone;
            public virtual HorizontalAlignment LogoHorizontalAlignment { get; set; } = HorizontalAlignment.Middle;
            public virtual VerticalAlignment LogoVerticalAlignment { get; set; } = VerticalAlignment.Middle;
            public virtual Rectangle LogoArea { get; set; } = new Rectangle(0, 0, 1, 1);
            public virtual double AspectRange { get; set; } = 0;
            public virtual bool Enlarge { get; set; } = true;
            public virtual IBitmap<I> Process(IBitmap<I> clearLogo) => Spine.ProcessTemplate(this, clearLogo);
            public void Dispose()
            {
                if (Image != null)
                {
                    Image.Dispose();
                    Image = null;
                }
            }
        }

        public static IBitmap<T> ProcessTemplate<T>(Template<T> template, IBitmap<T> clearLogo)
        {

            IBitmap<T> output;

            IBitmap<T> resizedLogo = clearLogo.Clone().TrimPixels().Rotate(template.LogoRotation);

            double perfectRatio = (double)(template.LogoArea.Width) / (double)(template.LogoArea.Height);
            double ratioDifference = ((double)(resizedLogo.Width) / (double)(resizedLogo.Height)) - perfectRatio;


            if (Math.Abs(ratioDifference) < template.AspectRange)
            {
                resizedLogo = resizedLogo.Resize(template.LogoArea.Size, template.Enlarge);
            }
            else
            {
                resizedLogo = resizedLogo.ResizeToFit(template.LogoArea.Size, template.Enlarge);
            }

            int logoX = 0;
            int logoY = 0;

            switch (template.LogoHorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    logoX = template.LogoArea.X;
                    break;

                case HorizontalAlignment.Middle:
                    logoX = template.LogoArea.X + ((template.LogoArea.Width / 2) - (resizedLogo.Width / 2));
                    break;

                case HorizontalAlignment.Right:
                    logoX = template.LogoArea.X + template.LogoArea.Width - resizedLogo.Width / 2;
                    break;
            }

            switch (template.LogoVerticalAlignment)
            {
                case VerticalAlignment.Top:
                    logoY = template.LogoArea.Y;
                    break;

                case VerticalAlignment.Middle:
                    logoY = template.LogoArea.Y + ((template.LogoArea.Height / 2) - (resizedLogo.Height / 2));
                    break;

                case VerticalAlignment.Bottom:
                    logoY = template.LogoArea.Y + template.LogoArea.Height - resizedLogo.Height;
                    break;
            }

            output = template.Image.Clone().DrawImage(resizedLogo.Bitmap, new Point(logoX, logoY));


            return output;
        }
    }
}
