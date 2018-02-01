using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using custom_installer.ViewModel;

namespace custom_installer.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void Main_Frame_Navigated(object sender, NavigationEventArgs e)
        {
            FrameworkElement el = Main_Frame.NavigationService.Content as FrameworkElement;
            if (el != null)
            {
                buttonsPannel.DataContext = el.DataContext;
                return;
            }
        }
    }
}
