using System;
using System.Collections.Generic;
using System.ComponentModel;
using Salon_Pro_APP.Constants;
using Salon_Pro_APP.Views;
using Xamarin.Forms;

namespace Salon_Pro_APP.ViewModels
{
    public class HomePageViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Data> DataSourceList;
        private string _backgroundColor;

        public HomePageViewModel()
        {
            BackgroundColor = ApplicationConstant.BackgroundColor;
            DataSourceList = new List<Data>();
            DataSourceList.Add(new Data() { Title = ApplicationConstant.DashboardPageMenuTitle, ImagePath = ApplicationConstant.DashboardLinkMenuIcon });
            DataSourceList.Add(new Data() { Title = ApplicationConstant.Link1MenuTitle, ImagePath = ApplicationConstant.Link1MenuIcon });
            DataSourceList.Add(new Data() { Title = ApplicationConstant.Link2MenuTitle, ImagePath = ApplicationConstant.Link2MenuIcon });
            DataSourceList.Add(new Data() { Title = ApplicationConstant.Link3MenuTitle, ImagePath = ApplicationConstant.Link3MenuIcon });
            DataSourceList.Add(new Data() { Title = ApplicationConstant.Link4MenuTitle, ImagePath = ApplicationConstant.Link4MenuIcon });
            DataSourceList.Add(new Data() { Title = ApplicationConstant.Link5MenuTitle, ImagePath = ApplicationConstant.Link5MenuIcon });
            DataSourceList.Add(new Data() { Title = ApplicationConstant.Link6MenuTitle, ImagePath = ApplicationConstant.Link6MenuIcon });
            DataSourceList.Add(new Data() { Title = ApplicationConstant.Link7MenuTitle, ImagePath = ApplicationConstant.Link7MenuIcon });
            DataSourceList.Add(new Data() { Title = ApplicationConstant.LinkFeedbackMenuTitle, ImagePath = ApplicationConstant.LinkFeedbackMenuIcon });
          
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

        /// <summary>
        /// Data model to bind list source data
        /// </summary>
        public class Data
        {
            public string Title
            {
                get;
                set;
            }
            public ImageSource ImagePath
            {
                get;
                set;
            }
        }
    }
}

