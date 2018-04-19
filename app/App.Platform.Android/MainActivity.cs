using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using App.Core;
using App.Platform.Android.Clients;
using App.Platform.Android.Plugins;

namespace App.Platform.Android
{
    // TODO: Handle logs and errors.
    // TODO: Check if navigation error also arrives in OnConsoleMessage (error is a console message?).
    // TODO: Scaling issues.
    // TODO: Back button.
    [Activity(Label = "App.Android", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, Theme = "@android:style/Theme.NoTitleBar")]
    public sealed class MainActivity : Activity
    {
        private Bridge _bridge;
        private WebView _webView;

        #region Overrides of Activity

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Initialize the component.
            base.OnCreate(savedInstanceState);

            // Initialize the content.
            SetContentView(Resource.Layout.Main);
            _webView = FindViewById<WebView>(Resource.Id.webView);
            _bridge = new Bridge(new BridgeClient(_webView), new CorePlugin(this));
            
            // Initialize the view.
            _webView.Settings.DomStorageEnabled = true;
            _webView.Settings.JavaScriptEnabled = true;
            _webView.SetWebChromeClient(new ChromeClient(_bridge));
            _webView.SetWebViewClient(new WebClient());
            _webView.LoadUrl("file:///android_asset/index.html");
        }

        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            if (keyCode != Keycode.Back || !_webView.CanGoBack()) return base.OnKeyDown(keyCode, e);
            _webView.GoBack();
            return true;
        }
        
        protected override void OnPause()
        {
            base.OnPause();
            _bridge.UpdateActiveState(false);
        }

        protected override void OnResume()
        {
            base.OnResume();
            _bridge.UpdateActiveState(true);
        }

        #endregion
    }
}