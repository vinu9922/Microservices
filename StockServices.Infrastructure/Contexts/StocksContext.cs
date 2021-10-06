using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using StockServices.Core.Entites;

namespace StockServices.Infrastructure.Contexts
{
    public class StocksContext : DbContext
    {
        public StocksContext(DbContextOptions options): base(options)
        {

        }
        public  StocksContext()
        {

        }

        public virtual DbSet<Stocks> stock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Stocks>().HasKey(p => p.StockId);
            modelBuilder.Entity<Stocks>().Property(p => p.ComapnyName).HasMaxLength(30).IsRequired(true);
        }

        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=WINDOWS-UNR7VLH\\SQLEXPRESS; database=Day8; integrated security=true;");
            }
        }

    }
}
