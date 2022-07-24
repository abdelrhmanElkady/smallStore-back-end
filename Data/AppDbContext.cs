using Microsoft.EntityFrameworkCore;
using smallStore.Models;

namespace smallStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<SoldProduct> SoldProducts { get; set; }


    }
}
