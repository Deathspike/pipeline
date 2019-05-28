using App.Core.Models.Plugins;
using App.Core.Plugins;
using App.Platform.iOS.Utilities;

namespace App.Platform.iOS.Plugins
{
    public sealed class StoragePlugin : IStoragePlugin
    {
        private readonly StorageContainer _container;

        #region Constructor

        public StoragePlugin()
        {
            _container = new StorageContainer(nameof(StoragePlugin));
        }

        #endregion

        #region Implementation of IStoragePlugin

        public string Get(string key)
        {
            return _container.Get(key);
        }

        public void Set(StorageDataModel model)
        {
            _container.Set(model.Key, model.Value);
        }

        #endregion
    }
}