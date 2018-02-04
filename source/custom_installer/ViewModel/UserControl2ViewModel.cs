using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using custom_installer.View;
using custom_installer.Model;
using System.Windows.Input;
using System.Windows.Forms;
using System.IO;
using System.Windows;

namespace custom_installer.ViewModel
{
    class UserControl2ViewModel : UserControllBaseViewModel
    {
        public ICommand SetDestination { get; private set; }

        private string _destinationPath;

        public UserControl2ViewModel()
        {
            BackButton.IsEnabled = true;
            NextButton.IsEnabled = true;

            SetDestination = new RelayCommand(setDestination);
        }

        public string DestinationPath
        {
            get
            {
                string path  = DestinationModel.DestinationPath;
                _destinationPath = DestinationModel.DestinationPath;

                return path;
            }
            set
            {
                if (Directory.Exists(value))
                {
                    DestinationModel.DestinationPath = value;
                    _destinationPath = value;
                    NotifyPropertyChanged("DestinationPath");
                }
            }
        }

        public override void ButtonNextClick(object obj)
        {
            string question = String.Format("Are you sure you want to install files in to {0} directory?", DestinationModel.DestinationPath);
            if (System.Windows.MessageBox.Show(question, "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }

            UserControl3_installation userControl3 = new UserControl3_installation();
            UserControl3ViewModel userControl3_viewModel = new UserControl3ViewModel();
            userControl3.DataContext = userControl3_viewModel;
            Navigator.NavigationService.Navigate(userControl3);
        }

        private void setDestination(object obj)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.DestinationPath = dialog.SelectedPath.ToString();
                    NextButton.IsEnabled = true;
                }
                else if (!Directory.Exists(_destinationPath))
                {
                    NextButton.IsEnabled = false;
                }
            }
        }
    }
}
