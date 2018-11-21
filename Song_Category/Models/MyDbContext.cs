using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Song_Category.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<SongCategory> SongCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SongCategory;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongCategory>()
                .HasKey(sc => new { sc.SongId, sc.CategoryId });
        }
    }

    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SongCategory> SongCategories { get; set; }
    }
    public class  Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SongCategory> SongCategories { get; set; }
    }
    public class SongCategory
    {
        public int SongId { get; set; }
        public int CategoryId { get; set; }

        public Song Song { get; set; }
        public Category Category { get; set; }
    }
}
