using System;
using Foundation;
using Salon_Pro_APP.CustomRenderers;
using Salon_Pro_APP.iOS.Renderers;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace Salon_Pro_APP.iOS.Renderers
{
    public class HybridWebViewRenderer: ViewRenderer<HybridWebView, WKWebView>, IWKScriptMessageHandler, IWKNavigationDelegate
    {

        //append 1,2,3,4 just to indentify clicked option in callback method
        const string JavaScriptFunction = ""+
            "var meta = document.createElement('meta'); meta.name = 'viewport'; meta.content = 'width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no';var head = document.getElementsByTagName('head')[0];head.appendChild(meta);";
        WKUserContentController userController;
        public static HybridWebViewRenderer _hybridWebViewRenderer;


        public static HybridWebViewRenderer GetInstance()
        {
            return _hybridWebViewRenderer;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
        {
            base.OnElementChanged(e);
            _hybridWebViewRenderer = this;
            if (Control == null)
            {
                userController = new WKUserContentController();
                var script = new WKUserScript(new NSString(JavaScriptFunction), WKUserScriptInjectionTime.AtDocumentEnd, false);
                userController.AddUserScript(script);
                var config = new WKWebViewConfiguration { UserContentController = userController };
                var webView = new WKWebView(Frame, config);
                webView.NavigationDelegate = this;
                SetNativeControl(webView);
            }
            if (e.OldElement != null)
            {
                userController.RemoveAllUserScripts();
                var hybridWebView = e.OldElement as HybridWebView;
            }
            if (e.NewElement != null)
            {
                NSUrl url = new NSUrl(Element.Uri);
                NSMutableUrlRequest urlRequest = new NSMutableUrlRequest(url);
                Control.LoadRequest(urlRequest);
            }
        }

        /// <summary>
        /// Did the receive script message.call back method of hybridwebview
        /// </summary>
        /// <param name="userContentController">User content controller.</param>
        /// <param name="message">Message.</param>
        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
        }
        WKJavascriptEvaluationResult handler = (NSObject result, NSError err) =>
        {
            if (err != null)
            {
                System.Console.WriteLine(err);
            }
            if (result != null)
            {
                System.Console.WriteLine(result);
            }
        };
        [Export("webView:didFinishNavigation:")]
        public void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
        {
            Xamarin.Forms.MessagingCenter.Send<App, bool>((App)Xamarin.Forms.Application.Current, "LoadingBar", false);
        }

        [Export("webView:didFailNavigation:withError:")]
        public void DidFailNavigation(WKWebView webView, WKNavigation navigation, NSError error)
        {
            // If navigation fails, this gets called
            Xamarin.Forms.MessagingCenter.Send<App, bool>((App)Xamarin.Forms.Application.Current, "LoadingBar", false);
        }

        [Export("webView:didFailProvisionalNavigation:withError:")]
        public void DidFailProvisionalNavigation(WKWebView webView, WKNavigation navigation, NSError error)
        {
            // If navigation fails, this gets called
            Xamarin.Forms.MessagingCenter.Send<App, bool>((App)Xamarin.Forms.Application.Current, "LoadingBar", false);
        }

        [Export("webView:didStartProvisionalNavigation:")]
        public void DidStartProvisionalNavigation(WKWebView webView, WKNavigation navigation)
        {
            // When navigation starts, this gets called
            Console.WriteLine("DidStartProvisionalNavigation");
        }
    }
}

