using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace LoungerTest1.Produces
{
    public abstract class Produce : INotifyPropertyChanged
    {
        private ProduceType? produceType;
        private string name = string.Empty;
        private string fullName = string.Empty;
        private BitmapSource iconBitmapSource = null;

        public event PropertyChangedEventHandler PropertyChanged;

        protected ProduceType? ProductType
        {
            get { return produceType; }
            set
            {
                produceType = value;
                OnPropertyChanged("ProduceType");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        public BitmapSource Icon
        {
            get { return iconBitmapSource; }
            set
            {
                iconBitmapSource = value;
                OnPropertyChanged("Icon");
            }
        }

        protected BitmapSource ToBitmapSource(Bitmap bitmap)
        {
            BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
                bitmap.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            return bitmapSource;
        }

        protected void Lounge()
        {
            Process.Start(fullName);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum ProduceType
    {
        Directory = 1, File = 2
    }
}
