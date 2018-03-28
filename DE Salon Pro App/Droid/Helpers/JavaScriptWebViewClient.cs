using System;
using Android.OS;
using Android.Webkit;

namespace Salon_Pro_APP.Droid.Helpers
{
    public class JavaScriptWebViewClient: WebViewClient
    {
        private bool IfError = false;
        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);
            Xamarin.Forms.MessagingCenter.Send<App, bool>((App)Xamarin.Forms.Application.Current, "LoadingBar", false);
        }
        public override void OnReceivedSslError(WebView view, SslErrorHandler handler, Android.Net.Http.SslError error)
        {
            base.OnReceivedSslError(view, handler, error);
            Xamarin.Forms.MessagingCenter.Send<App, bool>((App)Xamarin.Forms.Application.Current, "LoadingBar", false);
        }
        public override void OnPageCommitVisible(WebView view, string url)
        {
            base.OnPageCommitVisible(view, url);
            Xamarin.Forms.MessagingCenter.Send<App, bool>((App)Xamarin.Forms.Application.Current, "LoadingBar", false);
        }
        public override bool OnRenderProcessGone(WebView view, RenderProcessGoneDetail detail)
        {
            return base.OnRenderProcessGone(view, detail);
        }
        public override void OnReceivedError(WebView view, IWebResourceRequest request, WebResourceError error)
        {
            base.OnReceivedError(view, request, error);
            Xamarin.Forms.MessagingCenter.Send<App, bool>((App)Xamarin.Forms.Application.Current, "LoadingBar", false);
        }
        public override void OnReceivedHttpError(WebView view, IWebResourceRequest request, WebResourceResponse errorResponse)
        {
            base.OnReceivedHttpError(view, request, errorResponse);
            Xamarin.Forms.MessagingCenter.Send<App, bool>((App)Xamarin.Forms.Application.Current, "LoadingBar", false);
        }
    }
}

