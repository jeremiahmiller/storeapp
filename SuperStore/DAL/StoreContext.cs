using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SuperStore.Models;

namespace SuperStore.DAL
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Customer> Customers { get; set; } 
    }
}
