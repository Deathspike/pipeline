using App.Core.Plugins;
using App.Platform.iOS.Clients;
using UIKit;

namespace App.Platform.iOS.Plugins
{
    public sealed class ShellPlugin : IShellPlugin
    {
        #region Implementation of IShellPlugin

        public void HideSplashScreen()
        {
            (UIApplication.SharedApplication.KeyWindow.RootViewController as ViewClient)?.HideSplashScreen();
        }

        #endregion
    }
}