using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WEBAPI.Model
{
    public class AdultContext:DbContext
    {
        public AdultContext(DbContextOptions<AdultContext> options) : base(options)
        { }
        public DbSet<Adult>Adults{ get; set; }
    }
}
