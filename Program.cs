using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageQuickSave
{
    class Program
    {
        private const String saveFileDialogFilter = "PNG-Image (*.png)|*.png|JPEG-Image (*.jpg)|*.jpg|TIFF Image (*.tiff)|*.tiff";
        private static readonly ImageFormat[] imageFormats = { ImageFormat.Png, ImageFormat.Jpeg, ImageFormat.Tiff };

        [STAThreadAttribute]
        static void Main(string[] args)
        {
            if (Clipboard.ContainsImage())
            {
                var image = Clipboard.GetImage();
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = saveFileDialogFilter;
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat format = imageFormats[saveFileDialog.FilterIndex - 1];
                    image.Save(saveFileDialog.FileName, format);
                }
            }
        }
    }
}