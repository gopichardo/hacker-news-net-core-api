using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Story
    {
        public string title { get; set; }
        public string uri { get; set; }
        public string postedBy { get; set; }
        public string time { get; set; }
        public int score { get; set; }
        public int commentCount { get; set; }
    }
}