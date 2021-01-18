using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace UsingValidation.ViewModel
{
    /// <summary>
    /// A standard implementation of INotifyPropertyChanged.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {

        
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel()
        {

        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
