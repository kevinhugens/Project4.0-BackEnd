﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string linkStream { get; set; }
        public DateTime StartStream { get; set; }
        public DateTime EndStream { get; set; }
        public string Description { get; set; }
        public int? UserID { get; set; }
        public User Moderator { get; set; }
    }
}
