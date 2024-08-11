using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyAppleShop.Models;

namespace MyAppleShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Watch> watches { get; set; }
        public DbSet<ProductPurchase> ProductPurchases { get; set; }
        public DbSet<WatchPurchase> WatchPurchases { get; set; }


    }
}

