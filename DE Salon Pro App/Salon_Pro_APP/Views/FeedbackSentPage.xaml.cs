using System;
using System.Collections.Generic;
using Salon_Pro_APP.ViewModels;
using Xamarin.Forms;

namespace Salon_Pro_APP.Views
{
    public partial class FeedbackSentPage : ContentPage
    {
        FeedbackSentViewModel _viewModel;
        public FeedbackSentPage()
        {
            InitializeComponent();
            _viewModel = new FeedbackSentViewModel();
            BindingContext = _viewModel;
        }
    }
}
