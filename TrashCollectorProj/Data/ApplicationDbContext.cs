using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrashCollectorProj.Models;

namespace TrashCollectorProj.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Employee", NormalizedName = "Employee" }, new IdentityRole { Name = "Customer", NormalizedName = "Customer" });
            
          
        }

        public DbSet<Customer> Customer { get; set; }

       public  DbSet<Employee> Employee { get; set; }
    }
}
