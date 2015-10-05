using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insight.Core.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Insight.Core.Identity
{
    public class User : IdentityUser
    {
    }

    public class InsightContext : IdentityDbContext<User>
    { 
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            EmployeeMap(modelBuilder);
        }

        private void EmployeeMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Key(b => b.Id);

            modelBuilder.Entity<Employee>()
                .Property(b => b.Username)
                .MaxLength(100)
                .Required();

            modelBuilder.Entity<Employee>()
                .Property(b => b.FirstName)
                .MaxLength(100)
                .Required();

            modelBuilder.Entity<Employee>()
                .Property(b => b.LastName)
                .MaxLength(100)
                .Required();

            modelBuilder.Entity<Employee>()
                .Property(b => b.Email)
                .Required();

            modelBuilder.Entity<Employee>()
                .Property(b => b.TimestampCreated)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Employee>()
                .Property(b => b.TimestampModified)
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnAddOrUpdate();

            //max length
            modelBuilder.Entity<Employee>()
                .Property(b => b.Role)
                .MaxLength(100);

            modelBuilder.Entity<Employee>()
                .Property(b => b.Company)
                .MaxLength(250);

            modelBuilder.Entity<Employee>()
                .Property(b => b.Company)
                .MaxLength(250);

            modelBuilder.Entity<Employee>()
                .Property(b => b.Department)
                .MaxLength(100);

            modelBuilder.Entity<Employee>()
                .Property(b => b.Description)
                .MaxLength(1000);

            //indexes
            modelBuilder.Entity<Employee>()
                .Index(b => b.Username)
                .Unique();

            modelBuilder.Entity<Employee>()
                .Index(p => new { p.TimestampCreated, p.LastName, p.FirstName });
        }
    }
}
