﻿using System;
using System.ComponentModel;
using Salon_Pro_APP.Constants;
using Xamarin.Forms;

namespace Salon_Pro_APP.ViewModels
{
    public class Link1ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isBusy;
        private string _webURL;
        private string _title;
       
        private string _backgroundColor;

        public Link1ViewModel()
        {
            WebURL = ApplicationConstant.Link1URL;
            IsBusy = true;
            Title = ApplicationConstant.Link1MenuTitle;
            BackgroundColor = ApplicationConstant.BackgroundColor;
          
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


