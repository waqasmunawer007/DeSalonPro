using System;
using System.Collections.Generic;
using Salon_Pro_APP.ViewModels;
using Xamarin.Forms;

namespace Salon_Pro_APP.Views
{
    public partial class FeedbackPage : ContentPage
    {
        FeedbackViewModel _viewModel;
        public FeedbackPage()
        {
            InitializeComponent();
            _viewModel = new FeedbackViewModel(Navigation);
            BindingContext = _viewModel;
        }
		protected override void OnAppearing()
		{
            base.OnAppearing();
            MessagingCenter.Subscribe<App, bool>((App)Application.Current,"EmailStatusEvent", (s, status) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    _viewModel.IsBusy = false;
                    if (status)
                    {
                        Application.Current.MainPage = new HomePage() { Detail = new NavigationPage(new FeedbackSentPage()) };
                    }
                });

            });
		}
		protected override void OnDisappearing()
		{
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<App, bool>((App)Application.Current, "EmailStatusEvent");
		}

        void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            _viewModel.IsCheck = e.Value;
        }
	}
}
