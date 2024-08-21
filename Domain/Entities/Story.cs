using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Domain.Entities
{
    [JsonObject]
    public class Story
    {
        public string title { get; set; }
        [JsonProperty("url")]
        public string uri { get; set; }

        [JsonProperty("by")]
        public string postedBy { get; set; }
        public string time { get; set; }
        public int score { get; set; }
        public int commentCount { get; set; }
    }
}