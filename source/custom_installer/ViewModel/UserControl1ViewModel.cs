using custom_installer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custom_installer.ViewModel
{
    class UserControl1ViewModel : UserControllBaseViewModel
    {
        public UserControl1ViewModel()
        {
            BackButton.IsEnabled = false;
        }

        public override void ButtonNextClick(object obj)
        {
            UserControl2_setup userControl2 = new UserControl2_setup();
            UserControl2ViewModel userControll2_viewModel = new UserControl2ViewModel();
            userControl2.DataContext = userControll2_viewModel;
            Navigator.NavigationService.Navigate(userControl2);
        }
    }
}
