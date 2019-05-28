using Android.Content;
using App.Core.Models.Plugins;
using App.Core.Plugins;
using App.Platform.Android.Utilities;

namespace App.Platform.Android.Plugins
{
    public sealed class StoragePlugin : IStoragePlugin
    {
        private readonly StorageContainer _container;

        #region Constructor

        public StoragePlugin(Context context)
        {
            _container = new StorageContainer(context, nameof(StoragePlugin));
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