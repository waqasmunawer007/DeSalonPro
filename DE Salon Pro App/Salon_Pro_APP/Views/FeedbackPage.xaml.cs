using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Salon_Pro_APP.Views
{
    public partial class FeedbackPage : ContentPage
    {
        public FeedbackPage()
        {
            InitializeComponent();
        }
		protected override void OnAppearing()
		{
            base.OnAppearing();
            MessagingCenter.Subscribe<App, bool>((App)Application.Current,"EmailStatusEvent", (s, status) =>
            {
               
            });
		}
		protected override void OnDisappearing()
		{
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<App, bool>((App)Application.Current, "EmailStatusEvent");
		}
	}
}
