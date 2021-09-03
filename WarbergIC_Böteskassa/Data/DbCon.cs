using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarbergIC_Böteskassa.Models;

namespace WarbergIC_Böteskassa.Data
{
    public class DbCon : DbContext
    {

        public DbCon(DbContextOptions<DbCon> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasMany(c => c.Böteslista).WithOne(b => b.Åtalad);
           

            modelBuilder.Entity<Böter>().ToTable("Böter");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Regler>().ToTable("Regler");
        }

        public DbSet<Böter> böter { get; set; }
        public DbSet<Person> person { get; set; }
        public DbSet<Regler> regler { get; set; }
    }
}
