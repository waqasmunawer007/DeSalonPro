﻿using System;
using System.Collections.Generic;
using Salon_Pro_APP.Constants;
using Salon_Pro_APP.CustomRenderers;
using Salon_Pro_APP.ViewModels;
using Xamarin.Forms;

namespace Salon_Pro_APP.Views
{
    public partial class Link_1 : ContentPage
    {
        HybridWebView hybridWebView;
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
            ConfigureWebView();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<App, bool>((App)Xamarin.Forms.Application.Current, "LoadingBar");
        }
        private void ConfigureWebView()
        {
            _viewModel.IsBusy = true;
            var layout = new AbsoluteLayout()
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill

            };
            ActivityIndicator activityIndicator = new ActivityIndicator();
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");
            activityIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");
            hybridWebView = new HybridWebView
            {
                Uri = ApplicationConstant.Link1URL,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            hybridWebView.SetBinding(VisualElement.IsVisibleProperty, "IsWebViewVisible");

            AbsoluteLayout.SetLayoutBounds(hybridWebView, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(hybridWebView, AbsoluteLayoutFlags.All);
            layout.Children.Add(hybridWebView);

            AbsoluteLayout.SetLayoutBounds(activityIndicator, new Rectangle(0.5, 0.5, -1, -1));
            AbsoluteLayout.SetLayoutFlags(activityIndicator, AbsoluteLayoutFlags.PositionProportional);
            layout.Children.Add(activityIndicator);
            Content = layout;
        }
    }
}
