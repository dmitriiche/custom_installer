using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using custom_installer.View;
using custom_installer.ViewModel;

namespace custom_installer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainViewModel viewModel = new MainViewModel();
            MainWindow main = new MainWindow();
            Navigator.NavigationService = main.Main_Frame.NavigationService;
            main.DataContext = viewModel;
            main.Show();

            UserControl1_invitation UserControl1 = new UserControl1_invitation();
            UserControl1ViewModel userControl1_viewModel = new UserControl1ViewModel();
            UserControl1.DataContext = userControl1_viewModel;
            Navigator.NavigationService.Navigate(UserControl1);
        }
    }
}
