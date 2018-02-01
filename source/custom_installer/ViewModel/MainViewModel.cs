using System;
using System.Diagnostics;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using Prism.Commands;
using System.ComponentModel;

namespace custom_installer.ViewModel
{
    class MainViewModel : BindableBase
    {

        public MainViewModel()
        {

        }


    }

    public class Navigator
    {
        public static NavigationService NavigationService { get; set; }

        public static void Cancel()
        {
            App.Current.Shutdown(1);
        }
    }
}
