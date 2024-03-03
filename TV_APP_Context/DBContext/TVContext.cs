using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TV_APP_Context.Models;

namespace TV_APP_Context.DBContext
{
    public class TVContext : DbContext
    {
        public DbSet<Events> Events { get; set; }
        public DbSet<Videos> Videos { get; set; }


        public TVContext()  : base("DefaultConnection")
        { 

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
