using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using FFImageLoading.Forms.Touch;
using FFImageLoading.Transformations;
using Foundation;
using Plugin.Connectivity;
using Salon_Pro_APP.Constants;
using UIKit;
using Xamarin.Forms;

namespace Salon_Pro_APP.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        App mainApplication;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            CachedImageRenderer.Init();
            var ignore1 = typeof(CircleTransformation);
            global::Xamarin.Forms.Forms.Init();
            mainApplication = new App();
            MessagingCenter.Subscribe<App, string>(mainApplication, "EmailEvent", (s, error) =>
            {
                SendFeedbackEmail(error);
            });
            LoadApplication(mainApplication);

            return base.FinishedLaunching(app, options);
        }
        public override void WillTerminate(UIApplication uiApplication)
        {
            base.WillTerminate(uiApplication);
            MessagingCenter.Unsubscribe<App, string>(mainApplication,"EmailEvent");
        }

        private static void SendFeedbackEmail(string errorMessage)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    var client = new SmtpClient
                    {
                        Port = ApplicationConstant.EmailPort,
                        Host = ApplicationConstant.EmailHost,
                        EnableSsl = true,
                        Timeout = ApplicationConstant.EmailTimeout,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new System.Net.NetworkCredential(ApplicationConstant.EmailAddress, ApplicationConstant.EmailPassword)
                    };
                    var mailAddress = new MailAddress(ApplicationConstant.EmailAddress, "IOS App");
                    var mail = new MailMessage(mailAddress, mailAddress);
                    mail.Subject = ApplicationConstant.IPhoneFeedbackEmailSubject;
                    mail.Body = "This is test email";
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    client.Send(mail);
                    MessagingCenter.Send((App)Xamarin.Forms.Application.Current, "EmailStatusEvent",true);
                }
                catch (Exception ex)
                {
                    MessagingCenter.Send((App)Xamarin.Forms.Application.Current, "EmailStatusEvent", false);
                    Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "Close");
                }
            }
            else
            {
                MessagingCenter.Send((App)Xamarin.Forms.Application.Current, "EmailStatusEvent", false);
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("No Internet!","Please check your internet settings and then try again.","Close");
            }

        }
    }
}
