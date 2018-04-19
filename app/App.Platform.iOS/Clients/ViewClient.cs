using System;
using Foundation;
using UIKit;
using WebKit;

namespace App.Platform.iOS.Clients
{
    public sealed class ViewClient : UIViewController, IWKUIDelegate
    {
        private readonly WKWebView _webView;
        private UIStatusBarStyle _statusBarStyle;
  
        #region Constructor

        public ViewClient(WKWebView webView)
        {
            _statusBarStyle = UIStatusBarStyle.Default;
            _webView = webView;
        }

        #endregion

        #region Methods

        public void HideSplashScreen()
        {
            if (View.Subviews.Length != 2) return;
            _statusBarStyle = UIStatusBarStyle.LightContent;
            SetNeedsStatusBarAppearanceUpdate();
            View.Subviews[1].RemoveFromSuperview();
        }

        #endregion

        #region Overrides of UIViewController

        public override void LoadView()
        {
            _webView.UIDelegate = this;
            View = _webView;
        }

        public override UIStatusBarStyle PreferredStatusBarStyle()
        {
            return _statusBarStyle;
        }

        #endregion

        #region Implementation of IWKUIDelegate

        [Export("webView:runJavaScriptAlertPanelWithMessage:initiatedByFrame:completionHandler:")]
        public void RunJavaScriptAlertPanel(WKWebView webView, string message, WKFrameInfo frame, Action completionHandler)
        {
            var controller = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            controller.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, x => completionHandler()));
            PresentViewController(controller, true, null);
        }

        [Export("webView:runJavaScriptConfirmPanelWithMessage:initiatedByFrame:completionHandler:")]
        public void RunJavaScriptConfirmPanel(WKWebView webView, string message, WKFrameInfo frame, Action<bool> completionHandler)
        {
            var controller = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            controller.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, x => completionHandler(true)));
            controller.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Default, x => completionHandler(false)));
            PresentViewController(controller, true, null);
        }

        [Export("webView:runJavaScriptTextInputPanelWithPrompt:defaultText:initiatedByFrame:completionHandler:")]
        public void RunJavaScriptTextInputPanel(WKWebView webView, string prompt, string defaultText, WKFrameInfo frame, Action<string> completionHandler)
        {
            var controller = UIAlertController.Create(null, prompt, UIAlertControllerStyle.Alert);
            controller.AddTextField(textField =>
            {
                textField.Placeholder = defaultText;
                controller.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, x => completionHandler(textField.Text)));
                controller.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Default, x => completionHandler(null)));
                PresentViewController(controller, true, null);
            });
        }

        #endregion
    }
}