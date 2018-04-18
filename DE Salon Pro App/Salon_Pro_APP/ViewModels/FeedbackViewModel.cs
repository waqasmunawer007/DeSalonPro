using System;
using System.ComponentModel;
using Plugin.Messaging;
using Salon_Pro_APP.Constants;
using Xamarin.Forms;

namespace Salon_Pro_APP.ViewModels
{
    public class FeedbackViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command CallCommand { get; set; }
        public Command SubmitButtonCommand { get; set; }
       
        private string _title;
        private string _phoneNumber, _preferenceMessage,_firstName,_lastName,_email,_comments;
        private bool _isBusy,_isCheck;
      
        INavigation _navigation;

        public FeedbackViewModel(INavigation navigation)
        {
            _navigation = navigation;
           
            Title = ApplicationConstant.LinkFeedbackMenuTitle;
            PhoneNumber = ApplicationConstant.PhoneNumber;
            PreferenceMessage = ApplicationConstant.FeedbackPreference;
            CallCommand = new Command((e) =>
            {
                var phoneDialer = CrossMessaging.Current.PhoneDialer;
                if (phoneDialer.CanMakePhoneCall)
                    phoneDialer.MakePhoneCall(PhoneNumber);
            });
            SubmitButtonCommand = new Command((e) =>
            {
                if (!String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Comments))
                {
                    IsBusy = true;
                    System.Threading.Tasks.Task.Run(() =>
                    {
                        string emailBody = "First Name : " + FirstName + Environment.NewLine + "LastName: " + LastName
                                            +Environment.NewLine +  "Email: " + Email +Environment.NewLine + "EmailSubcription: "+ IsCheck
                                         + Environment.NewLine +"Comments: " +Comments;
                       
                        MessagingCenter.Send((App)Xamarin.Forms.Application.Current, "EmailEvent", emailBody);
                      
                    }).ConfigureAwait(false);

                   
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Error!", "Email or Comments can't be empty.", "OK");
                }
            });

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
        public bool IsCheck
        {
            get { return _isCheck; }
            set
            {
                _isCheck = value;
                OnPropertyChanged("IsCheck");
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
        public string Comments
        {
            get { return _comments; }
            set
            {
                _comments = value;
                OnPropertyChanged("Comments");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        public string PreferenceMessage
        {
            get { return _preferenceMessage; }
            set
            {
                _preferenceMessage = value;
                OnPropertyChanged("PreferenceMessage");
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


