﻿using System;
using System.Collections.Generic;
using Salon_Pro_APP.Constants;
using Salon_Pro_APP.CustomRenderers;
using Salon_Pro_APP.ViewModels;
using Xamarin.Forms;

namespace Salon_Pro_APP.Views
{
    public partial class Link_7 : ContentPage
    {
        Link7ViewModel _viewModel;
    
        public Link_7()
        {
            InitializeComponent();
            _viewModel = new Link7ViewModel();
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
