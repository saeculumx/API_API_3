using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WEBAPI.Model
{
    public class AdultContext:DbContext
    {
        public AdultContext()
        { 

        }
        public DbSet<Adult> Adults { get; set; }
        public AdultContext(DbContextOptions<AdultContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Adults.db");
        }
    }
}
