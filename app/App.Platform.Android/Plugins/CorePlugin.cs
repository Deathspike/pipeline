using Android.App;
using App.Core;

namespace App.Platform.Android.Plugins
{
    public sealed class CorePlugin : ICorePlugin
    {
        #region Constructor

        public CorePlugin(Activity activity)
        {
            Shell = new ShellPlugin(activity);
        }

        #endregion

        #region Implementation of ICorePlugin

        public IShellPlugin Shell { get; }

        #endregion
    }
}