using App.Core.Bridge;
using App.Platform.iOS.Clients;
using App.Platform.iOS.Plugins;
using CoreGraphics;
using Foundation;
using UIKit;
using WebKit;

namespace App.Platform.iOS
{
    // TODO: Handle logs and errors.
    [Register("AppDelegate")]
    public sealed class AppDelegate : UIApplicationDelegate
    {
        private Bridge _bridge;

        #region Overrides of UIApplicationDelegate

        public override void DidEnterBackground(UIApplication application)
        {
            _bridge.UpdateActiveState(false);
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Initialize the content controller.
            var userContentController = new WKUserContentController();
            var userContentMessageHandler = new WebClient();
            userContentController.AddScriptMessageHandler(userContentMessageHandler, "native");

            // Initialize the content.
            var webViewConfig = new WKWebViewConfiguration {UserContentController = userContentController};
            var webView = new WKWebView(UIScreen.MainScreen.Bounds, webViewConfig);
            _bridge = new Bridge(new BridgeClient(webView), new CorePlugin());
            userContentMessageHandler.UseBridge(_bridge);

            // Initialize the view.
            var viewUrl = new NSUrl(NSBundle.MainBundle.PathForResource("index", "html"), false);
            webView.LoadFileUrl(viewUrl, viewUrl);
            webView.ScrollView.ScrollEnabled = false;

            // Initialize the splash screen.
            var launchScreen = NSBundle.MainBundle.LoadNib("LaunchScreen", null, null);
            var launchView = launchScreen.GetItem<UIView>(0);
            launchView.Frame = new CGRect(0, -application.StatusBarFrame.Height, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height + application.StatusBarFrame.Height);

            // Initialize the window.
            Window = new UIWindow(new CGRect(0, application.StatusBarFrame.Height, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height - application.StatusBarFrame.Height));
            Window.RootViewController = new ViewClient(webView);
            Window.RootViewController.View.AddSubview(launchView);
            Window.MakeKeyAndVisible();
            return true;
        }

        public override void OnActivated(UIApplication application)
        {
            _bridge.UpdateActiveState(true);
        }
        
        public override UIWindow Window
        {
            get;
            set;
        }

        #endregion
    }
}