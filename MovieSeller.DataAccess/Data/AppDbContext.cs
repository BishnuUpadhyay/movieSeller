using Microsoft.EntityFrameworkCore;
using movieSeller.Models.Models;

namespace movieSeller.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                 new Category { Id = 2, Name = "Comedy", DisplayOrder = 2 },
                  new Category { Id = 3, Name = "History", DisplayOrder = 3 },
                   new Category { Id = 4, Name = "new", DisplayOrder = 4 }
                );
            modelBuilder.Entity<Product>().HasData(
    new Product { Id = 1, Title = "Fortune of Time", Author = "Billy", Description = "Movies number 1", ISBN = "121321231d", ListPrice = 99, Price = 90, Price50 = 85, Price100 = 80 },
     new Product { Id = 2, Title = "HariHari", Author = "SomeOnr", Description = "Movies number 2", ISBN = "121321231d", ListPrice = 109, Price = 100, Price50 = 95, Price100 = 90 },
         new Product { Id = 3, Title = "Fortune of Time", Author = "Billy", Description = "Movies number 1", ISBN = "121321231d", ListPrice = 99, Price = 90, Price50 = 85, Price100 = 80 },
     new Product { Id = 4, Title = "HariHari", Author = "SomeOnr", Description = "Movies number 2", ISBN = "121321231d", ListPrice = 109, Price = 100, Price50 = 95, Price100 = 90 }
    );
        }
    }
}
