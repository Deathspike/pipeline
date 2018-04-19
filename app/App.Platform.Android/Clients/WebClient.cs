using System;
using Android.Webkit;

namespace App.Platform.Android.Clients
{
    public sealed class WebClient : WebViewClient
    {
        #region Overrides of WebViewClient

        public override void OnReceivedError(WebView view, IWebResourceRequest request, WebResourceError error)
        {
            Console.WriteLine($"${nameof(WebClient)}: ${request.Url.ToString()} (${error.ErrorCode})");
            base.OnReceivedError(view, request, error);
        }
        
        #endregion
    }
}