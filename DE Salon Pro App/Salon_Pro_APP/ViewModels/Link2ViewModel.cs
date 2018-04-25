using System;
using System.ComponentModel;
using Salon_Pro_APP.Constants;

namespace Salon_Pro_APP.ViewModels
{
    public class Link2ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isBusy;
        private string _webURL;
        private string _title;
        private string _tabIcon;
        private string _backgroundColor;

        public Link2ViewModel()
        {
            WebURL = ApplicationConstant.Link2WebUrl;
            IsBusy = true;
            Title = ApplicationConstant.Link2MenuTitle;
            BackgroundColor = ApplicationConstant.BackgroundColor;
            TabIcon = ApplicationConstant.tab2Icon;
        }

        #region Properties
        public string TabIcon
        {
            get { return _tabIcon; }
            set
            {
                _tabIcon = value;
                OnPropertyChanged("TabIcon");
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
        public string BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                OnPropertyChanged("BackgroundColor");
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

