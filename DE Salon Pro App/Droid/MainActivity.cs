using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Droid;
using FFImageLoading.Transformations;
using System.Net.Mail;
using Plugin.Connectivity;
using System.Text;
using Salon_Pro_APP.Constants;
using Xamarin.Forms;


namespace Salon_Pro_APP.Droid
{
    [Activity(Label = "DE Salon Pro", Icon = "@drawable/ic_launcher", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        App app;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            CachedImageRenderer.Init(true);
            var ignore1 = typeof(CircleTransformation);
            app = new App();
            MessagingCenter.Subscribe<App, string>(app, "EmailEvent", (s, data) =>
            {
                SendFeedbackEmail(data);
            });
            LoadApplication(app);
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            MessagingCenter.Unsubscribe<App, string>(app, "EmailEvent");
        }

        private static void SendFeedbackEmail(string emailBody)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    var client = new SmtpClient
                    {
                        Port = ApplicationConstant.EmailPort,
                        Host = ApplicationConstant.EmailHost,
                        EnableSsl = false,
                        Timeout = ApplicationConstant.EmailTimeout,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new System.Net.NetworkCredential(ApplicationConstant.EmailAddress, ApplicationConstant.EmailPassword)
                    };

                    var mailAddress = new MailAddress(ApplicationConstant.EmailAddress, "Android APP");
                    var mail = new MailMessage(mailAddress, mailAddress);
                    mail.Subject = ApplicationConstant.AndroidFeedbackEmailSubject;
                    mail.Body = emailBody;
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    client.Send(mail);
                    MessagingCenter.Send((App)Xamarin.Forms.Application.Current, "EmailStatusEvent", true);
                }
                catch (Exception ex)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        MessagingCenter.Send((App)Xamarin.Forms.Application.Current, "EmailStatusEvent", false);
                        Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "Close");
                    });
                   
                }
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    MessagingCenter.Send((App)Xamarin.Forms.Application.Current, "EmailStatusEvent", false);
                    Xamarin.Forms.Application.Current.MainPage.DisplayAlert("No Internet!", "Please check your internet settings and then try again.", "Close");
                });
            }

        }

    }
}
