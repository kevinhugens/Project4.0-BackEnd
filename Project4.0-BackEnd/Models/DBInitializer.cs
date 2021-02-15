using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Project4._0_BackEnd.Data;
using Project4._0_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.models
{
    public class DBInitializer
    {
        public static void Initialize(ProjectContext context)
        {
            context.Database.EnsureCreated();

            // Look for any user.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            #region Users

            byte[] saltAdmin = Hashing.getSalt();
            context.Users.AddRange(
            new User
            {
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@admin.be",
                Password = Hashing.getHash("admin", saltAdmin),
                HashSalt = saltAdmin,
                Role = "admin",
            });
            byte[] saltUser1 = Hashing.getSalt();
            context.Users.AddRange(
                new User
                {
                    FirstName = "user1",
                    LastName = "user1",
                    Email = "user1@testing.be",
                    Password = Hashing.getHash("user1", saltUser1),
                    HashSalt = saltUser1,
                    Role = "user",
                });
            byte[] saltUser2 = Hashing.getSalt();
            context.Users.AddRange(
                new User
                {
                    FirstName = "user2",
                    LastName = "user2",
                    Email = "user2@testing.be",
                    Password = Hashing.getHash("user2", saltUser2),
                    HashSalt = saltUser2,
                    Role = "user",
                });
            byte[] saltUser3 = Hashing.getSalt();
            context.Users.AddRange(
                new User
                {
                    FirstName = "user3",
                    LastName = "user3",
                    Email = "user3@testing.be",
                    Password = Hashing.getHash("user3", saltUser3),
                    HashSalt = saltUser3,
                    Role = "user",
                });
            byte[] saltUser4 = Hashing.getSalt();
            context.Users.AddRange(
                new User
                {
                    FirstName = "user4",
                    LastName = "user4",
                    Email = "user4@testing.be",
                    Password = Hashing.getHash("user4", saltUser4),
                    HashSalt = saltUser3,
                    Role = "user",
                });
            byte[] saltUser5 = Hashing.getSalt();
            context.Users.AddRange(
                new User
                {
                    FirstName = "user5",
                    LastName = "user5",
                    Email = "user5@testing.be",
                    Password = Hashing.getHash("user5", saltUser5),
                    HashSalt = saltUser5,
                    Role = "user",
                });
            byte[] saltUser6 = Hashing.getSalt();
            context.Users.AddRange(
                new User
                {
                    FirstName = "user6",
                    LastName = "user6",
                    Email = "user6@testing.be",
                    Password = Hashing.getHash("user6", saltUser6),
                    HashSalt = saltUser6,
                    Role = "user",
                });
            byte[] saltJohn = Hashing.getSalt();
            context.Users.AddRange(
                new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@testing.be",
                    Password = Hashing.getHash("johndoe", saltJohn),
                    HashSalt = saltJohn,
                    Role = "user",
                });
            byte[] saltJane = Hashing.getSalt();
            context.Users.AddRange(
                new User
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "janedoe@testing.be",
                    Password = Hashing.getHash("janedoe", saltJane),
                    HashSalt = saltJane,
                    Role = "user",
                });
            byte[] saltJos = Hashing.getSalt();
            context.Users.AddRange(
                new User
                {
                    FirstName = "Jos",
                    LastName = "Vermeulen",
                    Email = "josvermeulen@testing.be",
                    Password = Hashing.getHash("josvermeulen", saltJos),
                    HashSalt = saltJos,
                    Role = "user",
                });
            byte[] saltJef = Hashing.getSalt();
            context.Users.AddRange(
                new User
                {
                    FirstName = "Jef",
                    LastName = "Verstraten",
                    Email = "jefverstraten@testing.be",
                    Password = Hashing.getHash("jefverstraten", saltJef),
                    HashSalt = saltJef,
                    Role = "user",
                });

            #endregion
            context.SaveChanges();

            #region Rooms

            context.Rooms.AddRange(
                new Room
                {
                    Name = "Room 1",
                    StartStream = DateTime.UtcNow,
                    EndStream = DateTime.Now,
                    Description = "Dit is de beschrijving van room 1",
                    PresentatorID = 2,
                    ModeratorID = 3
                });
            context.Rooms.AddRange(
                new Room
                {
                    Name = "Room 2",
                    Password = "room2",
                    StartStream = DateTime.UtcNow,
                    EndStream = DateTime.Now,
                    Description = "Dit is de beschrijving van room 2",
                    PresentatorID = 4
                });

            #endregion
            context.SaveChanges();

            #region Polls
            context.Polls.AddRange(
                new Poll
                {
                    Question = "Question 1?",
                    RoomID = 1,
                });

            #endregion
            context.SaveChanges();
            #region Options
            context.Options.AddRange(
                new Option { Content = "A", PollID = 1 }
                );
            context.Options.AddRange(
                new Option { Content = "B", PollID = 1 }
                );
            context.Options.AddRange(
                new Option { Content = "C", PollID = 1 }
                );

            #endregion
            context.SaveChanges();
        }
    }
}
