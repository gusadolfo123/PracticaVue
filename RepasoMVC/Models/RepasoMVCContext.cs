using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RepasoMVC.Models
{
    public class RepasoMVCContext: DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public RepasoMVCContext(): base(nameof(RepasoMVCContext))
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasKey(c => c.CategoryID);
            modelBuilder.Entity<Category>().Property(c => c.Description).HasMaxLength(200);

            modelBuilder.Entity<Product>().HasKey(p => p.ProductID);
            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasMaxLength(80);
            modelBuilder.Entity<Product>().HasIndex(p => new { p.ProductName, p.CategoryID }).IsUnique(true);

            base.OnModelCreating(modelBuilder); 
        }

    }
}