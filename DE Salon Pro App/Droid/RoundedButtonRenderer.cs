using System;
using Android.Content;
using Salon_Pro_APP.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Button), typeof(RoundedButtonRenderer))]
namespace Salon_Pro_APP.Droid
{
    public class RoundedButtonRenderer : ButtonRenderer
    {
        public RoundedButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnDraw(Android.Graphics.Canvas canvas)
        {
            base.OnDraw(canvas);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            if (e != null)
            {
                base.OnElementChanged(e);


            }
        }
    }
}
