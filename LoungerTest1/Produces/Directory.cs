using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LoungerTest1.Produces
{
    class Directory : Produce
    {
        public Directory(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            ProductType = ProduceType.Directory;
            Name = directoryInfo.Name;
            FullName = directoryInfo.FullName;
            Icon = new BitmapImage(new Uri("/Images/folder-26.png", UriKind.Relative));
        }
    }
}
