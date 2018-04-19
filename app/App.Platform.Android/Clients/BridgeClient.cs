using Android.Webkit;
using App.Core.Bridge;

namespace App.Platform.Android.Clients
{
    public sealed class BridgeClient : IClient
    {
        private readonly WebView _webView;
        
        #region Constructor

        public BridgeClient(WebView webView)
        {
            _webView = webView;
        }

        #endregion

        #region Implementation of IClient

        public void Submit(string functionName, SubmitData data)
        {
            _webView.Post(() => _webView.EvaluateJavascript($"{functionName}({data.InvokeData});", null));
        }

        #endregion
    }
}