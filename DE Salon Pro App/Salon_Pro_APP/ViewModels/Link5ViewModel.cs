using System;
using System.ComponentModel;
using Salon_Pro_APP.Constants;

namespace Salon_Pro_APP.ViewModels
{
    public class Link5ViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isBusy;
        private string _webURL;
        private string _title;

        public Link5ViewModel()
        {
            WebURL = ApplicationConstant.Link5WebUrl;
            IsBusy = true;
            Title = ApplicationConstant.Link5MenuTitle;
        }
        #region Properties
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        public string WebURL
        {
            get { return _webURL; }
            set
            {
                _webURL = value;
                OnPropertyChanged("WebURL");
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

