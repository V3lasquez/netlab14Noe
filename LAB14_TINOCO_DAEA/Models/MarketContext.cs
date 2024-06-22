﻿using Microsoft.EntityFrameworkCore;

namespace LAB14_TINOCO_DAEA.Models
{
    public class MarketContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Detail> Details { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAB1504-17\\SQLEXPRESS;Initial Catalog=MarketDB;User Id=user;Password=user03; trustservercertificate=True");
        }
    }
}
