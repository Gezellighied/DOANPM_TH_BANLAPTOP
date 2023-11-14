using System.Collections.Generic;
using DOANPM_TH.Models.ClassModel;
using Microsoft.EntityFrameworkCore;
namespace DOANPM_TH.Models.ViewModel
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laptops>()
                .HasKey(o => new { o.LaptopID });
            
        }*/
        public DbSet<Laptops> Laptops { get; set; }
        public DbSet<Customer> Customers { get; set; }
        
        //public DbSet<Cart> Carts { get; set; }
        //public DbSet<CartItem> CartItems { get; set; }
    }
}
    