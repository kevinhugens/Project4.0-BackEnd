using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class Poll
    {
        public int PollID { get; set; }
        public string Question { get; set; }
        public int RoomID { get; set; }
        public Room Room { get; set; }
        public List<Option> Options { get; set; }
    }
}
