using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NewsManager.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<New> News { get; set; }
        public DbSet<Category> Categories { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<New>()
                .HasOne(n => n.Category)
                .WithMany(c => c.News)
                .HasForeignKey(n => n.CategoryId);
 
            base.OnModelCreating(modelBuilder);
        }

    }
}