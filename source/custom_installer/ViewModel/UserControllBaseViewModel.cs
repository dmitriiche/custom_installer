using custom_installer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custom_installer.ViewModel
{
    public abstract class UserControllBaseViewModel : INotifyPropertyChanged
    {
        protected ButtonViewModel _buttonCancel;
        protected ButtonViewModel _buttonBack;
        protected ButtonViewModel _buttonNext;

        public UserControllBaseViewModel()
        {}

        public virtual ButtonViewModel CancelButton
        {
            get
            {
                if (_buttonCancel == null)
                {
                    _buttonCancel = new ButtonViewModel()
                    {
                        IsEnabled = true,
                        Text = "Cancel",
                        Command = new RelayCommand(ButtonCancelClick)
                    };
                }
                return _buttonCancel;
            }
            set 
            {
                _buttonCancel = value;
                NotifyPropertyChanged("Cancel");
            }    
        }

        public virtual ButtonViewModel BackButton
        {
            get
            {
                if (_buttonBack == null)
                {
                    _buttonBack = new ButtonViewModel()
                    {
                        IsEnabled = true,
                        Text = "Back",
                        Command = new RelayCommand(ButtonBacklClick)
                    };
                }
                return _buttonBack;
            }
            set
            {
                _buttonBack = value;
                NotifyPropertyChanged("Back");
            }
        }

        public virtual ButtonViewModel NextButton
        {
            get
            {
                if (_buttonNext == null)
                {
                    _buttonNext = new ButtonViewModel()
                    {
                        IsEnabled = true,
                        Text = "Next",
                        Command = new RelayCommand(ButtonNextClick)
                    };
                }
                return _buttonNext;
            }
            set
            {
                _buttonNext = value;
                NotifyPropertyChanged("Next");
            }
        }

        /// <summary>
        /// Button lambda functions
        /// </summary>
        public virtual void ButtonBacklClick(object obj)
        {
            Navigator.NavigationService.GoBack();
        }

        public virtual void ButtonCancelClick(object obj)
        {
            Navigator.Cancel();
        }

        public abstract void ButtonNextClick(object obj);

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
}
