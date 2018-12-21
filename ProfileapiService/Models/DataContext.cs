using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProfileapiService.Models
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=(localdb)\\MyInstance;Database=RECRUITMENT;Trusted_Connection=True;");
        }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<ProfileSkillSet> ProfileSkillSet { get; set; }
    }
}

