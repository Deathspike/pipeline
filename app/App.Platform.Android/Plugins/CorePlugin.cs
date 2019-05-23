using Android.App;
using App.Core.Plugins;

namespace App.Platform.Android.Plugins
{
    public sealed class CorePlugin : ICorePlugin
    {
        #region Constructor

        public CorePlugin(Activity activity)
        {
            Shell = new ShellPlugin(activity);
            Storage = new StoragePlugin(activity);
        }

        #endregion

        #region Implementation of ICorePlugin

        public IShellPlugin Shell { get; }

        public IStoragePlugin Storage { get; }

        #endregion
    }
}