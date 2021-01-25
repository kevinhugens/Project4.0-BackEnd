using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class UserPoll
    {
        public int UserPollID { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
        public int? PollID { get; set; }
        public Poll? Poll { get; set; }
        public int? OptionID { get; set; }
        public Option? Option { get; set; }
    }
}
