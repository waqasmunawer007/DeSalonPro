
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Salon_Pro_APP.Droid
{
    [Activity(Label="BASIC Hair",MainLauncher=true,Theme="@style/Theme.Splash",NoHistory=true,Icon="@drawable/ic_launcher")]  
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));  

            // Create your application here
        }
    }
}
