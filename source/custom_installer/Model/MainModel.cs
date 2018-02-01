using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custom_installer.Model
{
    public class MainModel : INotifyPropertyChanged
    {
        private bool _isaborted;
        private decimal _progress;
        private bool _isDone;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainModel()
        {
            _isaborted = false;
        }

        public bool IsAborted
        {
            get { return _isaborted; }
            set { _isaborted = value; }
        }

        public bool IsDone
        {
            get { return _isDone; }
            set { }
        }

        public int Progress
        {
            get { return Decimal.ToInt32(Decimal.Round(_progress)); }
            private set
            {
                _progress = value;
                NotifyPropertyChanged("Progress");
            }
        }

        public void RunCopyTask()
        {
            Task.Run(() => CopyTask());
        }

        private void CopyTask()
        {
            String source_directory = "";
            if (new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory + "tiedostot").Exists)
            {
                source_directory = System.AppDomain.CurrentDomain.BaseDirectory + "tiedostot";
            }
            else if (new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory + "Tiedostot").Exists)
            {
                source_directory = System.AppDomain.CurrentDomain.BaseDirectory + "Tiedostot";
            }
            else
            {
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "Tiedostot");
                source_directory = System.AppDomain.CurrentDomain.BaseDirectory + "Tiedostot";
            }

            int fCount = Directory.GetFiles(source_directory, "*", SearchOption.AllDirectories).Length;
            decimal progressStep = 1000;
            if (fCount > 0)
            {
                progressStep = 1000 / fCount;
            }

            String destination_directory = DestinationModel.DestinationPath;

            DirectoryCopy(source_directory, destination_directory, progressStep);
            _isDone = true;
            Progress = 1000;
            NotifyPropertyChanged("IsDone");
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, decimal progressStep)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                return;
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                if (_isaborted)
                { break; }

                string temppath = System.IO.Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
                _progress += progressStep;
                NotifyPropertyChanged("Progress");
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                if (_isaborted)
                { break; }
                string temppath = System.IO.Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath, progressStep);
            }
        }

        protected void NotifyPropertyChanged(string fieldname)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(fieldname);
                handler(this, e);
            }

        }
    }

    public static class DestinationModel
    {
        private static string _destination_path;

        static DestinationModel()
        {
            //_destination_path = "";//System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            _destination_path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        }

        public static string DestinationPath
        {
            get { return _destination_path; }
            set { _destination_path = value; }
        }
    }
}
