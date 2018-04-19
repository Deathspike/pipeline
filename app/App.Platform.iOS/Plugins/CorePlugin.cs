using App.Core;

namespace App.Platform.iOS.Plugins
{
    public sealed class CorePlugin : ICorePlugin
    {
        #region Constructor

        public CorePlugin()
        {
            Shell = new ShellPlugin();
        }

        #endregion

        #region Implementation of ICorePlugin
        
        public IShellPlugin Shell { get; }

        #endregion
    }
}