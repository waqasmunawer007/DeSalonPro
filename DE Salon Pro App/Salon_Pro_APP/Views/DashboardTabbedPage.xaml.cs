using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Salon_Pro_APP.Views
{
    public partial class DashboardTabbedPage : TabbedPage
    {
        public DashboardTabbedPage()
        {
            InitializeComponent();

            Link_1 link1 = new Link_1();
            Children.Add(link1);

            Link_2 link2 = new Link_2();
            Children.Add(link2);

            Link_3 link3 = new Link_3();
            Children.Add(link3);

            Link_4 link4 = new Link_4();
            Children.Add(link4);

            Link_5 link5 = new Link_5();
            Children.Add(link5);

            Link_6 link6 = new Link_6();
            Children.Add(link6);

            Link_7 link7 = new Link_7();
            Children.Add(link7);

            Link_8 link8 = new Link_8();
            Children.Add(link8);
        }
    }
}
