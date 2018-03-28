using System;
using System.Collections.Generic;
using Salon_Pro_APP.ViewModels;
using Xamarin.Forms;

namespace Salon_Pro_APP.Views
{
    public partial class Link_5 : ContentPage
    {
        Link5ViewModel _viewModel;
        public Link_5()
        {
            InitializeComponent();
            _viewModel = new Link5ViewModel();
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<App, bool>((App)Xamarin.Forms.Application.Current, "LoadingBar", (s, barStatus) =>
            {
                _viewModel.IsBusy = barStatus;
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<App, bool>((App)Xamarin.Forms.Application.Current, "LoadingBar");
        }
    }
}
