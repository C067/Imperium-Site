using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImperiumSite.Data
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Leaderboard> Leaderboard { get; set; }
        public virtual DbSet<PasswordReset> PasswordReset { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=mymysql.senecacollege.ca;database=db_cdodge1;user=db_cdodge1;password=}c89qfXn)Y");
        }
    }
}
