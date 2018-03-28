using System;
using System.ComponentModel;
using Salon_Pro_APP.Constants;

namespace Salon_Pro_APP.ViewModels
{
    public class Link7ViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isBusy;
        private string _webUrl;
        private string _title;
        public Link7ViewModel()
        {
            WebUrl = ApplicationConstant.Link7WebUrl;
            IsBusy = true;
            Title = ApplicationConstant.Link7MenuTitle;
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
        public string WebUrl
        {
            get { return _webUrl; }
            set
            {
                _webUrl = value;
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


