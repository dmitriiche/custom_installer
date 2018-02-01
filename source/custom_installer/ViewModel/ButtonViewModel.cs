using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace custom_installer.ViewModel
{
    public class ButtonViewModel : INotifyPropertyChanged
    {
        protected bool _IsEnabled;
        protected buttonCommand _Command;
        protected string _text; 

        public ButtonViewModel()
        {

        }

        public virtual ICommand Command
        {
            get { return _Command; }
            set
            {
                _Command = value as buttonCommand;
                NotifyPropertyChanged("Command");
            }
            
        }

        public virtual bool IsEnabled
        {
            get { return _IsEnabled; }
            set
            {
                _IsEnabled = value;
                NotifyPropertyChanged("IsEnabled");
            }
        }

        public virtual string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                NotifyPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string fieldname)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(fieldname);
                handler(this, e);
            }

        }
    }

    public class buttonCommand : ICommand
    {
        Action<object> _execute;

        public buttonCommand(Action<object> execute)
        {
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
         //   throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
