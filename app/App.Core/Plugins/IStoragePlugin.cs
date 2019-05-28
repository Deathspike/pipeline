using App.Core.Models.Plugins;

namespace App.Core.Plugins
{
    public interface IStoragePlugin
    {
        string Get(string key);

        void Set(StorageDataModel model);
    }
}