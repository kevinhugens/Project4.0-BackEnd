using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class UserInRoom
    {
        public int UserInRoomID { get; set; }
        public int? UserID { get; set; }
        public User User { get; set; }
        public int RoomID { get; set; }
        public Room Room { get; set; }
        public Boolean IsModerator { get; set; }
    }
}
