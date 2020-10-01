using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoungerTest1
{
    public class LoungerEngine : INotifyPropertyChanged
    {
        private ObservableCollection<Produces.Produce> producesCollection;
        private string request;
        bool first = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Produces.Produce> ProducesCollection
        {
            get { return producesCollection; }
            set
            {
                producesCollection = value;
                OnPropertyChanged("ProducesCollection");
            }
        }

        public LoungerEngine()
        {
            producesCollection = new ObservableCollection<Produces.Produce>();
        }

        public void ProcessRequest(string request)
        {
            producesCollection.Clear();
            this.request = request.ToLower();

            DirectoryInfo[] assignedDirectoryInfos = new DirectoryInfo[7];
            assignedDirectoryInfos[0] = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            assignedDirectoryInfos[1] = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop");
            assignedDirectoryInfos[2] = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads");
            assignedDirectoryInfos[3] = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            assignedDirectoryInfos[4] = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            assignedDirectoryInfos[5] = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            assignedDirectoryInfos[6] = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\OneDrive");

            for (int i = 0; i < assignedDirectoryInfos.Length; i++)
            {
                FileInfo[] childrenFileInfos = assignedDirectoryInfos[i].GetFiles();
                DirectoryInfo[] childrenDirectoryInfos = assignedDirectoryInfos[i].GetDirectories();

                for (int j = 0; j < childrenFileInfos.Length; j++)
                {
                    if (childrenFileInfos[j].Name.ToLower().Contains(this.request))
                        producesCollection.Add(new Produces.File(childrenFileInfos[j].FullName));
                }

                for (int j = 0; j < childrenDirectoryInfos.Length; j++)
                {
                    if (childrenDirectoryInfos[j].Name.ToLower().Contains(this.request))
                        producesCollection.Add(new Produces.Directory(childrenDirectoryInfos[j].FullName));
                    if (i > 0)
                        GetDirectoryContent(childrenDirectoryInfos[j]);
                }
            }
        }

        public void DropProduces()
        {
            producesCollection.Clear();
        }

        private void GetDirectoryContent(DirectoryInfo directoryInfo)
        {
            FileInfo[] childrenFileInfos = directoryInfo.GetFiles();
            DirectoryInfo[] childrenDirectoryInfos = directoryInfo.GetDirectories();

            for (int i = 0; i < childrenFileInfos.Length; i++)
            {
                if (childrenFileInfos[i].Name.ToLower().Contains(request))
                    producesCollection.Add(new Produces.File(childrenFileInfos[i].FullName));
            }

            for (int i = 0; i < childrenDirectoryInfos.Length; i++)
            {
                if (childrenDirectoryInfos[i].Name.ToLower().Contains(request))
                    producesCollection.Add(new Produces.Directory(childrenDirectoryInfos[i].FullName));
                GetDirectoryContent(childrenDirectoryInfos[i]);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
