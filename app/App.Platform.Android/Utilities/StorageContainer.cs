using Android.Content;

namespace App.Platform.Android.Utilities
{
    public sealed class StorageContainer
    {
        private readonly Context _context;
        private readonly string _name;

        #region Constructor

        public StorageContainer(Context context, string name)
        {
            _context = context;
            _name = name;
        }

        #endregion

        #region Methods

        public string Get(string key)
        {
            using (var preferences = _context.GetSharedPreferences(_name, FileCreationMode.Private))
            {
                return preferences.GetString(key, string.Empty);
            }
        }

        public void Set(string key, string value)
        {
            using (var preferences = _context.GetSharedPreferences(_name, FileCreationMode.Private))
            {
                if (string.IsNullOrEmpty(value))
                {
                    preferences.Edit().Remove(key).Commit();
                }
                else
                {
                    preferences.Edit().PutString(key, value).Commit();
                }
            }
        }

        #endregion
    }
}