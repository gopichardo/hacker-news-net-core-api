using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Domain.Entities
{
    public class StoryRepositoryDto : Story
    {

        public List<int>? kids { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime timeUnix { get; set; }
    }
}