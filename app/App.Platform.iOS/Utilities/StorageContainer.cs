using Foundation;

namespace App.Platform.iOS.Utilities
{
    public sealed class StorageContainer
    {
        private readonly string _name;

        #region Abstracts

        private string GetContainerKey(string key)
        {
            return string.IsNullOrEmpty(_name) ? key : $"{_name}:{key}";
        }

        #endregion

        #region Constructor

        public StorageContainer(string name)
        {
            _name = name;
        }

        #endregion

        #region Methods

        public string Get(string key)
        {
            return NSUserDefaults.StandardUserDefaults.StringForKey(GetContainerKey(key)) ?? string.Empty;
        }

        public void Set(string key, string value)
        {
            var containerKey = GetContainerKey(key);
            var userDefaults = NSUserDefaults.StandardUserDefaults;
            
            if (string.IsNullOrEmpty(value))
            {
                userDefaults.RemoveObject(containerKey);
                userDefaults.Synchronize();
            }
            else
            {
                userDefaults.SetString(value, containerKey);
                userDefaults.Synchronize();
            }
        }

        #endregion
    }
}