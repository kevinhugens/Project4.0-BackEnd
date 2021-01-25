using Microsoft.EntityFrameworkCore;
using Project4._0_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project4._0_BackEnd.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<UserInRoom> UserInRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Poll>().ToTable("Poll");
            modelBuilder.Entity<Option>().ToTable("Option");
            modelBuilder.Entity<UserInRoom>().ToTable("UserInRoom");
        }
    }
}
