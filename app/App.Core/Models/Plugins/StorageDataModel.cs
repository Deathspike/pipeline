using Newtonsoft.Json;

namespace App.Core.Models.Plugins
{
    public sealed class StorageDataModel
    {
        [JsonProperty]
        public string Key { get; set; }

        [JsonProperty]
        public string Value { get; set; }
    }
}