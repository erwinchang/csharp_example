using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfOfficeInterop
{
    public class Pdf2PngTemplate1
    {
        public static bool Test(ref string strRet)
        {
            bool flag = true;
            strRet = string.Empty;
            try
            {
                string docxFile = @"D:\template7_1.docx";
                string pdfFile = @"D:\template7_1.pdf";
                string page1File = @"D:\template7_1_page1.png";
                byte[] bitmap;
                using (FileStream fs = File.Open(pdfFile, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    bitmap = Freeware.Pdf2Png.Convert(fs, 1);
                }
                //GC.Collect();
                //GC.WaitForPendingFinalizers();
                BitmapImage bimage = LoadImage(bitmap);
                Save2Png(bimage, page1File);
            }
            catch (Exception ex)
            {
                flag = false;
                strRet = string.Format("[Test] {0}", ex.Message);
            }
            return flag;
        }
        //https://stackoverflow.com/questions/77946656/convert-pdf-to-pngs-with-freeware-pdf2png
        public void Convert(string input, string output)
        {
            //seleccionado = new FileStream(ruta_archivo, Filemode.OpenOrCreate, FileAccess.ReadWrite);
        }
        //https://stackoverflow.com/questions/9564174/convert-byte-array-to-image-in-wpf
        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        //https://stackoverflow.com/questions/35804375/how-do-i-save-a-bitmapimage-from-memory-into-a-file-in-wpf-c
        public static void Save2Png(BitmapImage image, string filePath)
        {
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));

            using (var fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
            {
                encoder.Save(fileStream);
            }
        }
    }
}
