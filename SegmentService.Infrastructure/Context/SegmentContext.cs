using Microsoft.EntityFrameworkCore;
using SegmentServiceCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegmentService.Infrastructure.Context
{
    public class SegmentContext:DbContext
    {
        public SegmentContext()
        {

        }

        public SegmentContext( DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Segment> seg { get; set; }
        public virtual DbSet<Company> company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=WINDOWS-UNR7VLH\\SQLEXPRESS; database=Day8; integrated security=true;");
            }
        }
        
        
        protected override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Segment>().HasKey(p => p.SegmentId);
            modelBuilder.Entity<Segment>().Property(p => p.SegmentName).IsRequired(true);
            modelBuilder.Entity<Company>().HasKey(p => p.CompanyId);
        }

    }
}
