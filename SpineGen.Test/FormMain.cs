using SpineGen.DrawingBitmaps;
using SpineGen.JSON;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SpineGen.Test
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var templateDir = new DirectoryInfo("templates");

            if (templateDir.Exists)
            {
                foreach (var dir in templateDir.GetDirectories())
                {
                    if (dir.GetFiles().Where(file => file.Name == "template.json" || file.Name == "template.png").Count() == 2)
                    {
                        templateSelector.Items.Add(SpineTemplate<Bitmap>.FromJsonFile(new SystemDrawingBitmap(Bitmap.FromFile(Path.Combine(dir.FullName, "template.png")) as Bitmap), Path.Combine(dir.FullName, "template.json")));
                    }
                }
            }
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private Bitmap GenerateSpineRow()
        {
            var width = templateSelector.Items.Count * 56;
            var height = 428;
            var image = new Bitmap(width + 8, height + 8, PixelFormat.Format32bppArgb);

            using (var g = Graphics.FromImage(image))
            {
                g.Clear(Color.Transparent);
                for (var i = 0; i < templateSelector.Items.Count; i++)
                {
                    g.DrawImage(((SpineTemplate<Bitmap>)templateSelector.Items[i]).Process(new SystemDrawingBitmap(clearLogo.Image as Bitmap)).Bitmap, new Point((56 * i) + 4, 4));
                }
            }
            return image;
        }
        private void GenerateSpine()
        {
            if (spineTemplate.Image != null && clearLogo.Image != null && templateSelector.SelectedItem != null)
            {
                var image = ((SpineTemplate<Bitmap>)templateSelector.SelectedItem).Process(new SystemDrawingBitmap(clearLogo.Image as Bitmap));
                spineOutput.Image = image.Bitmap;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                clearLogo.Image = Image.FromFile(s[i]);

            GenerateSpine();
            Clipboard.SetImage(GenerateSpineRow());
        }

        private void TemplateSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (templateSelector.SelectedItem == null)
                return;

            spineTemplate.Image = (templateSelector.SelectedItem as SpineTemplate<Bitmap>).Image.Bitmap;

            GenerateSpine();
        }
    }
}
