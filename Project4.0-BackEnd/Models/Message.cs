using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class Message
    {
        public string clientuniqueid { get; set; }
        public string message { get; set; }
        public int roomId { get; set; }
        public string username { get; set; }
        public DateTime date { get; set; }

        public Boolean isQuestion { get; set; }
        public Boolean isValidatedQuestion { get; set; }
        public Boolean isAcceptedQuestion { get; set; }
    }
}
