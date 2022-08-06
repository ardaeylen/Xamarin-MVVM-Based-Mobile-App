using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Last.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyname)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
