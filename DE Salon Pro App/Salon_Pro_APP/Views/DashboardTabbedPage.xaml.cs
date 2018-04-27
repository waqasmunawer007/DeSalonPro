using System;
using System.Collections.Generic;
using Salon_Pro_APP.ViewModels;
using Xamarin.Forms;

namespace Salon_Pro_APP.Views
{
    public partial class DashboardTabbedPage : ContentPage
    {
        DashboardViewModel _viewModel;
        public DashboardTabbedPage()
        {
            InitializeComponent();
            _viewModel = new DashboardViewModel(Navigation);
            BindingContext = _viewModel;
        }
    }
}
