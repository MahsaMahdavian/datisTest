using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConvertLinqApplication.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConvertLinqApplication.models
{
    public class DatabaseContext   : IdentityDbContext<User, Role, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer(@"Server=(local);Database=ConvertUrlDB;Trusted_Connection=True");
        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Visit>  Visits{ get; set; }
        public DbSet<Url> Urls { get; set; }
    }
}
