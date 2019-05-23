using App.Core.Models;

namespace App.Core.Plugins
{
    public interface IStoragePlugin
    {
        string Get(string key);

        void Set(StorageData data);
    }
}