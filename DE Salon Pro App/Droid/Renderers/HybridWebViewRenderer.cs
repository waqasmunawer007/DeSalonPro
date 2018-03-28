using System;
using System.Collections.Generic;
using Android.Content;
using Android.Webkit;
using Salon_Pro_APP.CustomRenderers;
using Salon_Pro_APP.Droid.Helpers;
using Salon_Pro_APP.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace Salon_Pro_APP.Droid.Renderers
{
    public class HybridWebViewRenderer: ViewRenderer<HybridWebView, Android.Webkit.WebView>
    {
        public static HybridWebViewRenderer _hybridWebViewRenderer;
        public Android.Webkit.WebView _webView;
       
        public HybridWebViewRenderer(Context context) : base(context)
        {
            _hybridWebViewRenderer = this;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                // MainPage.isBusy = true;
                _webView = new Android.Webkit.WebView(Forms.Context);
                _webView.Settings.JavaScriptEnabled = true;
                _webView.SetWebViewClient(new JavaScriptWebViewClient());
                _webView.SetWebChromeClient(new WebChromeClient());
                _webView.ClearCache(true);
                SetNativeControl(_webView);
            }
            if (e.OldElement != null)
            {
                Control.RemoveJavascriptInterface("jsBridge");
                var hybridWebView = e.OldElement as HybridWebView;
            }
            if (e.NewElement != null)
            {
                //Control.LoadUrl(string.Format("file:///android_asset/{0}", Element.Uri));
                Dictionary<string, string> headers = new Dictionary<string, string>();
                Control.LoadUrl(Element.Uri, headers);
                //InjectJS(JavaScriptFunction);
            }
        }
        void InjectJS(string script)
        {
            if (Control != null)
            {
                Control.LoadUrl(string.Format("javascript: {0}", script));
            }
        }
    }
}
