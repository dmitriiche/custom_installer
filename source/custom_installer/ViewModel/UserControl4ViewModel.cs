using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custom_installer.ViewModel
{
    class UserControl4ViewModel : UserControllBaseViewModel
    {
        public UserControl4ViewModel()
        {
            NextButton.IsEnabled = false;
            BackButton.IsEnabled = false;
            CancelButton.Text = "Exit";
        }

        public override void ButtonNextClick()
        {
        }
    }
}
