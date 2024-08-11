using System;
using Microsoft.EntityFrameworkCore;
using MyAppleShopApi.Models;

namespace MyAppleShopApi.DAL
{

    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Watch> watches { get; set; }

    }
}

