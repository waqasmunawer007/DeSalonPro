using System;
using System.Collections.Generic;
using Salon_Pro_APP.Constants;
using Salon_Pro_APP.ViewModels;
using Xamarin.Forms;
using static Salon_Pro_APP.ViewModels.HomePageViewModel;

namespace Salon_Pro_APP.Views
{
    
    public partial class HomePage : MasterDetailPage
    {
        private HomePageViewModel _viewModel;

        public HomePage()
        {
            InitializeComponent();
            _viewModel = new HomePageViewModel();
            BindingContext = _viewModel;
            mlist.ItemsSource = _viewModel.DataSourceList;
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
          //  this.IsPresented = false;
            Application.Current.MainPage = new HomePage() { Detail = new NavigationPage(new DashboardPage()) };

        }
        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var person = e.SelectedItem as Data;
            if ((person.Title).Equals(ApplicationConstant.Link1MenuTitle))
            {
                Detail = new NavigationPage(new Link_1());
                IsPresented = false;
            }

            else if ((person.Title).Equals(ApplicationConstant.Link2MenuTitle))
            {
                Detail = new NavigationPage(new Link_2());
                IsPresented = false;
            }
            else if ((person.Title).Equals(ApplicationConstant.Link3MenuTitle))
            {
                Detail = new NavigationPage(new Link_3());
                IsPresented = false;
            }
            else if ((person.Title).Equals(ApplicationConstant.Link4MenuTitle))
            {
                Detail = new NavigationPage(new Link_4());
                IsPresented = false;
            }
            else if ((person.Title).Equals(ApplicationConstant.Link5MenuTitle))
            {
                Detail = new NavigationPage(new Link_5());
                IsPresented = false;
            }
            else if ((person.Title).Equals(ApplicationConstant.Link6MenuTitle))
            {
                Detail = new NavigationPage(new Link_6());
                IsPresented = false;
            }
            else if ((person.Title).Equals(ApplicationConstant.Link7MenuTitle))
            {
                Detail = new NavigationPage(new Link_7());
                IsPresented = false;
            }
            else if ((person.Title).Equals("Log Out"))
            {
                IsPresented = false;
            }
            else
            {
                Detail = new NavigationPage(new DashboardPage());
                IsPresented = false;
            }
            mlist.SelectedItem = null;
        }
    }
}
