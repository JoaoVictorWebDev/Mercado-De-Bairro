﻿using Microsoft.EntityFrameworkCore;
using SuperMarket.Core.Entities;
namespace SuperMarket.Data.Contexts
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>()
                .HasKey(p => p.ProductID);
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}