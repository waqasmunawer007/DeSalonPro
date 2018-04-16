using System;
using System.Collections.Generic;
using Salon_Pro_APP.ViewModels;
using Xamarin.Forms;

namespace Salon_Pro_APP.Views
{
    public partial class DashboardPage : ContentPage
    {
        DashboardViewModel _viewModel;
        public DashboardPage()
        {
            InitializeComponent();
            _viewModel = new DashboardViewModel(Navigation);
            BindingContext = _viewModel;
        }
    }
}
