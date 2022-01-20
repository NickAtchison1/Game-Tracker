using Game_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Game_Tracker.DataModels
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("DefaultConnection") { }

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameSystem> GameSystems { get; set; }


    }
}