using System;
using System.ComponentModel;
using Salon_Pro_APP.Constants;

namespace Salon_Pro_APP.ViewModels
{
    public class Link6ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isBusy;
        private string _webURL;
        private string _title;
        private string _backgroundColor;
       

        public Link6ViewModel()
        {
            _webURL = ApplicationConstant.Link6WebUrl;
            Title = ApplicationConstant.Link6MenuTitle;
            BackgroundColor = ApplicationConstant.BackgroundColor;
            IsBusy = true;
          
        }

        #region Properties

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        public string BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                OnPropertyChanged("BackgroundColor");
            }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }
        public string WebUrl
        {
            get { return _webURL; }
            set
            {
                _webURL = value;
                OnPropertyChanged("UrlPartner");
            }
        }
        #endregion
        /// <summary>
        /// Ons the property changed.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

