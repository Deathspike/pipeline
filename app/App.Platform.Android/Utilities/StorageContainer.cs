using System;
using Android.Content;

namespace App.Platform.Android.Utilities
{
    public sealed class StorageContainer : IDisposable
    {
        private readonly ISharedPreferences _sharedPreferences;

        #region Constructor

        public StorageContainer(Context context, string name)
        {
            _sharedPreferences = context.GetSharedPreferences(name, FileCreationMode.Private);
        }

        #endregion

        #region Methods

        public string Get(string key)
        {
            return _sharedPreferences.GetString(key, string.Empty);
        }

        public void Set(string key, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                _sharedPreferences.Edit().Remove(key).Commit();
            }
            else
            {
                _sharedPreferences.Edit().PutString(key, value).Commit();
            }
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            _sharedPreferences.Dispose();
        }

        #endregion
    }
}