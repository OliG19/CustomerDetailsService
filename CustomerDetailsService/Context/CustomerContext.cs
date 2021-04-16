using CustomerDetailsService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CustomerDetailsService.DAL
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
            
        }

        public DbSet<EntityCustomer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityCustomer>()
                .ToTable("Customers");
            modelBuilder.Entity<EntityCustomer>()
                .Property(c => c.Name)
                .IsRequired(false);
            modelBuilder.Entity<EntityCustomer>()
                .Property(c => c.Age)
                .HasDefaultValue(true);
            modelBuilder.Entity<EntityCustomer>()
                .HasData(
                    new EntityCustomer
                    {
                        Id = Guid.Parse("f6cb0b55-49eb-420f-8958-db501d3ddd31"),
                        Name = "John Doe",
                        Age = 30
                    },
                    new EntityCustomer
                    {
                        Id = Guid.NewGuid(),
                        Name = "Jane Doe",
                        Age = 25
                    }
                );
        }

    }
}
