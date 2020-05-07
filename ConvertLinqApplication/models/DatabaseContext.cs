using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConvertLinqApplication.models
{
    public class DatabaseContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer(@"Server=(local);Database=ConvertUrlDB;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Visit>()
            //    .HasOne(u => u.Url)
            //    .WithOne(b => b.Visit)
            //    .HasForeignKey(b => b.UserId);
        }
        public DbSet<Visit>  Visits{ get; set; }
        public DbSet<Url> Urls { get; set; }
    }
}
