using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name=  "Action" , DisplayOrder = 1},
                new Category { Id = 2, Name = "Sci-Fi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Drama", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Comedy", DisplayOrder = 4 },
                new Category { Id = 5, Name = "History", DisplayOrder = 5 }

                );
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
