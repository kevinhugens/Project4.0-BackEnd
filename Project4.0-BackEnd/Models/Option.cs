using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class Option
    {
        public int OptionID { get; set; }
        public string Content { get; set; }
        public int PollID { get; set; }
        [JsonIgnore]
        public Poll Poll { get; set; }
    }
}
