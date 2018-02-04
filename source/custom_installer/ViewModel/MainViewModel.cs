using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using System.ComponentModel;

namespace custom_installer.ViewModel
{
    class MainViewModel
    {
        public MainViewModel()
        {}
    }

    /// <summary>
    /// Class that implements NavigationService
    /// </summary>
    public class Navigator
    {
        public static NavigationService NavigationService { get; set; }

        public static void Cancel()
        {
            App.Current.Shutdown(1);
        }
    }

    /// <summary>
    /// ICommand implementation
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Predicate<object> canExecute;
        private event EventHandler CanExecuteChangedInternal;

        public RelayCommand(Action<object> execute)
           : this(execute, DefaultCanExecute)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this.CanExecuteChangedInternal += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChangedInternal -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute != null && this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedInternal;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }
    }
}
