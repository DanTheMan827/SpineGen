using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using SpineGen.DrawingBitmaps;
using SpineGen.JSON;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpineGen.AvaloniaTest.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string test { get; set; } = "Hello";
        public Bitmap spineTemplate { get; set; }
        public Bitmap spinePreview { get; set; }
        public Bitmap clearLogo { get; set; }
        public List<SpineTemplate<System.Drawing.Bitmap>> spineTemplates { get => GetTemplates(); }
        public SpineTemplate<System.Drawing.Bitmap> selectedTemplate { get; set; }

        private Bitmap SystemDrawingToAvaloniaBitmap(System.Drawing.Bitmap bitmap)
        {
            using (var imageStream = new MemoryStream())
            {
                bitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
                imageStream.Seek(0, SeekOrigin.Begin);

                return new Bitmap(imageStream);
            }
        }

        private List<SpineTemplate<System.Drawing.Bitmap>> GetTemplates(string templateDirectory = "templates")
        {
            var output = new List<SpineTemplate<System.Drawing.Bitmap>>();
            var templateDir = new DirectoryInfo(templateDirectory);

            if (templateDir.Exists)
            {
                foreach (var dir in templateDir.GetDirectories())
                {
                    if (dir.GetFiles().Where(file => file.Name == "template.json" || file.Name == "template.png").Count() == 2)
                    {
                        output.Add(SpineTemplate<System.Drawing.Bitmap>.FromJsonFile(new SystemDrawingBitmap(System.Drawing.Image.FromFile(Path.Combine(dir.FullName, "template.png")) as System.Drawing.Bitmap), Path.Combine(dir.FullName, "template.json")));
                    }
                }
            }
            return output;
        }
        public MainWindowViewModel()
        {
            using (var image = new System.Drawing.Bitmap(500, 500, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
            using (var g = System.Drawing.Graphics.FromImage(image))
            using (var imageStream = new MemoryStream())
            {
                g.FillRectangle(System.Drawing.SystemBrushes.Highlight, 0, 0, image.Width, image.Height);

                image.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
                imageStream.Seek(0, SeekOrigin.Begin);
                var aBitmap = new Bitmap(imageStream);
                clearLogo = aBitmap;
            }
            this.PropertyChanged += MainWindowViewModel_PropertyChanged;
        }

        private void MainWindowViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
        }


    }
}
