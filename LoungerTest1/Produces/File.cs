using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoungerTest1.Produces
{
    class File : Produce
    {
        public File(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            ProductType = ProduceType.File;
            Name = fileInfo.Name;
            FullName = fileInfo.Name;

            switch(fileInfo.Extension)
            {
                case ".png":
                    Icon = ToBitmapSource(System.Drawing.Image.FromFile(path) as System.Drawing.Bitmap);
                    break;
                case ".jpg":
                    Icon = ToBitmapSource(System.Drawing.Image.FromFile(path) as System.Drawing.Bitmap);
                    break;
                case ".bmp":
                    Icon = ToBitmapSource(System.Drawing.Image.FromFile(path) as System.Drawing.Bitmap);
                    break;
                default:
                    Icon = ToBitmapSource(System.Drawing.Icon.ExtractAssociatedIcon(path).ToBitmap());
                    break;
            }
        }
    }
}
