using System;
using System.ComponentModel;
using Plugin.Messaging;
using Salon_Pro_APP.Constants;
using Salon_Pro_APP.Views;
using Xamarin.Forms;

namespace Salon_Pro_APP.ViewModels
{
    public class DashboardViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command Link1Command { get; set; }
        public Command Link2Command { get; set; }
        public Command Link3Command { get; set; }
        public Command Link4Command { get; set; }
        public Command Link5Command { get; set; }
        public Command Link6Command { get; set; }
        public Command Link7Command { get; set; }
        public Command Link8Command { get; set; }
       
        private string _mainTitle,_link1Image, _link2Image, _link3Image, _link4Image, _link5Image, 
        _link6Image, _link7Image,_link8Image;
        private string _bgImage;
        INavigation _navigation;

        public DashboardViewModel(INavigation navigation)
        {
            _navigation = navigation;
            SetupLinks();
            Link1Command = new Command((e) =>
            {
                _navigation.PushAsync(new Link_1());
            });
            Link2Command = new Command((e) =>
            {
                _navigation.PushAsync(new Link_2());
            });
            Link3Command = new Command((e) =>
            {
                _navigation.PushAsync(new Link_3());
            });
            Link4Command = new Command((e) =>
            {
                _navigation.PushAsync(new Link_4());
            });
            Link5Command = new Command((e) =>
            {
                _navigation.PushAsync(new Link_5());
            });
            Link6Command = new Command((e) =>
            {
                _navigation.PushAsync(new Link_6());
            });
            Link7Command = new Command((e) =>
            {
                _navigation.PushAsync(new Link_7());
            });
            Link8Command = new Command((e) =>
            {
                _navigation.PushAsync(new Link_8());
            });

           
        }
        private void SetupLinks()
        {
            BackgroundImage = ApplicationConstant.DashboardPageBGImage;
            MainTitle = ApplicationConstant.DashboardPageMenuTitle;
          
            Link1Image = ApplicationConstant.DashboardImageHolder1;
            Link2Image = ApplicationConstant.DashboardImageHolder2;
            Link3Image = ApplicationConstant.DashboardImageHolder3;
            Link4Image = ApplicationConstant.DashboardImageHolder4;
            Link5Image = ApplicationConstant.DashboardImageHolder5;
            Link6Image = ApplicationConstant.DashboardImageHolder6;
            Link7Image = ApplicationConstant.DashboardImageHolder7;
            Link8Image = ApplicationConstant.DashboardImageHolder8;
           
        }
        #region Properties
        public string BackgroundImage
        {
            get { return _bgImage; }
            set
            {
                _bgImage = value;
                OnPropertyChanged("BackgroundImage");
            }
        }
        public string MainTitle
        {
            get { return _mainTitle; }
            set
            {
                _mainTitle = value;
                OnPropertyChanged("MainTitle");
            }
        }

        public string Link1Image
        {
            get { return _link1Image; }
            set
            {
                _link1Image = value;
                OnPropertyChanged("Link1Image");
            }
        }
        public string Link2Image
        {
            get { return _link2Image; }
            set
            {
                _link2Image = value;
                OnPropertyChanged("Link2Image");
            }
        }
        public string Link3Image
        {
            get { return _link3Image; }
            set
            {
                _link3Image = value;
                OnPropertyChanged("Link3Image");
            }
        }
        public string Link4Image
        {
            get { return _link4Image; }
            set
            {
                _link4Image = value;
                OnPropertyChanged("Link4Image");
            }
        }
        public string Link5Image
        {
            get { return _link5Image; }
            set
            {
                _link5Image = value;
                OnPropertyChanged("Link5Image");
            }
        }
        public string Link6Image
        {
            get { return _link6Image; }
            set
            {
                _link6Image = value;
                OnPropertyChanged("Link6Image");
            }
        }

        public string Link7Image
        {
            get { return _link7Image; }
            set
            {
                _link7Image = value;
                OnPropertyChanged("Link7Image");
            }
        }
        public string Link8Image
        {
            get { return _link8Image; }
            set
            {
                _link8Image = value;
                OnPropertyChanged("Link8Image");
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


