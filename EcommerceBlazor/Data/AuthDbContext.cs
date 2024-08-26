using EcommerceBlazor.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBlazor.Data;

public class AuthDbContext:IdentityDbContext
{


    public AuthDbContext(DbContextOptions<AuthDbContext> options):base (options)
    {
        
    }
    
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var seedCategory = new List<Category>()
        {
            new Category()
            {
                Id = 1,
                Name = "Appetiser"
            },
            new Category()
            {
                Id = 2,
                Name = "Drink"
            },
            new Category()
            {
                Id = 3,
                Name = "Dessert"
            }
        };

        builder.Entity<Category>().HasData(seedCategory);
    }
}