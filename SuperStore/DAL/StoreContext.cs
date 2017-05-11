using ContosoUniversity.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SuperStore.Models;

namespace SuperStore.DAL
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Employee> Emplyees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public object Customer { get; internal set; }
        public object Employees { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Product>()
                .HasMany(c => c.Employees).WithMany(i => i.Product)
                .Map(t => t.MapLeftKey("ProductID")
                    .MapRightKey("EmployeeID")
                    .ToTable("ProductEmployee"));
        }
    }
}
