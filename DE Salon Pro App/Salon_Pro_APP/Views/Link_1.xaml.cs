using System;
using System.Collections.Generic;
using Salon_Pro_APP.ViewModels;
using Xamarin.Forms;

namespace Salon_Pro_APP.Views
{
    public partial class Link_1 : ContentPage
    {
        Link1ViewModel _viewModel;
        public Link_1()
        {
            InitializeComponent();
            _viewModel = new Link1ViewModel();
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
