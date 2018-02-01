using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using custom_installer.Model;
using custom_installer.View;
using Prism.Commands;

namespace custom_installer.ViewModel
{
    class UserControl3ViewModel : UserControllBaseViewModel
    {
        public ICommand OnLoadUserControll { get; private set; }
        private MainModel installationModel = new MainModel();

        public UserControl3ViewModel()
        {
            BackButton.IsEnabled = false;
            NextButton.IsEnabled = false;

            installationModel.PropertyChanged += InstallationModel_PropertyChanged;
            OnLoadUserControll = new DelegateCommand(onLoaduserControll);
        }

        public int Progress
        {
            get { return installationModel.Progress; }
            private set { }
        }

        public override void ButtonNextClick()
        {
            UserControl4_done userControl4 = new UserControl4_done();
            UserControl4ViewModel userControl4_viewModel = new UserControl4ViewModel();
            userControl4.DataContext = userControl4_viewModel;
            Navigator.NavigationService.Navigate(userControl4);
        }

        public override void ButtonCancelClick()
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                installationModel.IsAborted = true;
            }
            
            base.ButtonCancelClick();
        }

        private void onLoaduserControll()
        {
            installationModel.RunCopyTask();
        }

        private void InstallationModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Progress")
            {
                NotifyPropertyChanged("Progress");
            }
            else if (e.PropertyName == "IsDone")
            {
                NextButton.IsEnabled = true;
            }
        }
    }
}
