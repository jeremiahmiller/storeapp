using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SuperStore.Models;

namespace SuperStore.DAL
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var customer = new List<Customer>
            {
            new Customer{FirstName="Adam",LastName="Miller",PurchaseDate=DateTime.Parse("2005-09-01")},
            new Customer{FirstName="Sarah",LastName="Johnson",PurchaseDate=DateTime.Parse("2002-09-01")},
            new Customer{FirstName="John",LastName="Williams",PurchaseDate=DateTime.Parse("2003-09-01")},
            new Customer{FirstName="Mary",LastName="Moore",PurchaseDate=DateTime.Parse("2002-09-01")},
            new Customer{FirstName="James",LastName="Jones",PurchaseDate=DateTime.Parse("2002-09-01")},
            new Customer{FirstName="Peter",LastName="Brown",PurchaseDate=DateTime.Parse("2001-09-01")},
            new Customer{FirstName="Joseph",LastName="Smith",PurchaseDate=DateTime.Parse("2003-09-01")},
            new Customer{FirstName="Matthew",LastName="Davis",PurchaseDate=DateTime.Parse("2005-09-01")}
            };

            customer.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();
            var products = new List<Product>
            {
            new Product{ProductID=1050,Title="Think and Grow Rich",Price=10},
            new Product{ProductID=4022,Title="How to Win Friends and Influence People",Price=10},
            new Product{ProductID=4041,Title="The 7 Habits of Highly Effective People",Price=10},
            new Product{ProductID=1045,Title="No Excuses: The Power of Self Discipline",Price=10},
            new Product{ProductID=3141,Title="Power vs Force",Price=10},
            new Product{ProductID=2021,Title="The Emotion Code",Price=10},
            new Product{ProductID=2042,Title="The Holy Bible",Price=10},
            new Product{ProductID=2042,Title="The Book of Mormon",Price=10}
            };

            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();
            var purchases = new List<Purchase>
            {
            new Purchase{CustomerID=1,ProductID=1050},
            new Purchase{CustomerID=1,ProductID=4022},
            new Purchase{CustomerID=1,ProductID=4041},
            new Purchase{CustomerID=2,ProductID=1045},
            new Purchase{CustomerID=2,ProductID=3141},
            new Purchase{CustomerID=2,ProductID=2021},
            new Purchase{CustomerID=3,ProductID=1050},
            new Purchase{CustomerID=4,ProductID=1050},
            new Purchase{CustomerID=4,ProductID=4022},
            new Purchase{CustomerID=5,ProductID=4041},
            new Purchase{CustomerID=6,ProductID=1045},
            new Purchase{CustomerID=7,ProductID=3141}
            };
            purchases.ForEach(s => context.Purchases.Add(s));
            context.SaveChanges();
        }
    }
}
