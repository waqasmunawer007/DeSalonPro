using System;
using System.ComponentModel;
using Plugin.Messaging;
using Salon_Pro_APP.Constants;
using Xamarin.Forms;

namespace Salon_Pro_APP.ViewModels
{
    public class FeedbackSentViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command CallCommand { get; set; }
        private string _phoneNumber;


        public FeedbackSentViewModel()
        {
            PhoneNumber = ApplicationConstant.PhoneNumber;
            CallCommand = new Command((e) =>
            {
                var phoneDialer = CrossMessaging.Current.PhoneDialer;
                if (phoneDialer.CanMakePhoneCall)
                    phoneDialer.MakePhoneCall(PhoneNumber);
            });
        }

        #region Properties
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
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



