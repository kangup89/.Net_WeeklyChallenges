using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIUsageChallenge.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    class Person
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string FullName { get; set; }

        [JsonProperty]
        public string height { get; set; }

        [JsonProperty]
        public string mass { get; set; }

        [JsonProperty]
        public string hair_color { get; set; }

        [JsonProperty]
        public string skin_color { get; set; }

        [JsonProperty]
        public string eye_color { get; set; }

        [JsonProperty]
        public string birth_year { get; set; }

        [JsonProperty]
        public string gender { get; set; }

        [JsonProperty]
        public string homeworld { get; set; }

        [JsonProperty]
        public List<string> films { get; set; }

        [JsonProperty]
        public List<string> species { get; set; }

        [JsonProperty]
        public List<string> vehicles { get; set; }

        [JsonProperty]
        public List<string> starships { get; set; }

        [JsonProperty]
        public DateTime created { get; set; }

        [JsonProperty]
        public DateTime edited { get; set; }

        [JsonProperty]
        public string url { get; set; }
    }
}
