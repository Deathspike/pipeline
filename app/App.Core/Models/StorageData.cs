using Newtonsoft.Json;

namespace App.Core.Models
{
    public sealed class StorageData
    {
        [JsonProperty]
        public string Key { get; set; }

        [JsonProperty]
        public string Value { get; set; }
    }
}