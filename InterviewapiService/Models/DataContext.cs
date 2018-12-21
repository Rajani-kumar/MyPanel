using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InterviewapiService.Models
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MyInstance;Database=RECRUITMENT;Trusted_Connection=True;");
        }
        public DbSet<Interview> Interview { get; set; }
        public DbSet<InterviewHistory> InterviewHistory { get; set; }
        public DbSet<InterviewPannel> InterviewPannel { get; set; }
        
    }
}
