namespace SuperStore.Migrations
{
    using SuperStore.Models;
    using SuperStore.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StoreContext context)
        {
            var customers = new List<Customer>
            {
                new Customer { FirstName = "Jeremiah", LastName = "Miller", PurchaseDate = DateTime.Parse("2010-09-01") },
                new Customer { FirstName = "Brigham", LastName = "Young", PurchaseDate = DateTime.Parse("2010-09-01") },
                new Customer { FirstName = "Thomas", LastName = "Monson", PurchaseDate = DateTime.Parse("2010-09-01") },
                new Customer { FirstName = "Joseph", LastName = "Smith", PurchaseDate = DateTime.Parse("2010-09-01") }
            };
            customers.ForEach(s => context.Customers.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product {ProductID = 1050, Title = "Think and Grow Rich", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "How to Win Friends and Influence People", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "The 7 Habits of Highly Effecctive People", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "No Excuses: The Power of Self Discipline", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "Outliers", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "Rich Dad, Poor Dad", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "The 4 Hour Work Week", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "Power vs Force", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "The Emotion Code", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "The Holy Bible", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "The Book of Mormon", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "Jesus the Christ", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "The Infinite Atonement", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "The Miracle of Forgiveness ", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "The Inevitable Apostacy", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "The Blueprint of Christ's Church", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "The Elegant Universe", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "Joseph Smith: Rough Stone Rolling", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "Physics for Scientists and Engineers", Price = 10, Employees = new List<Employee>()},
                new Product {ProductID = 1050, Title = "Introduction to Experimental Chemistry", Price = 10, Employees = new List<Employee>()}
            };
            products.ForEach(s => context.Products.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var purchases = new List<Purchase>
            {
                new Purchase {
                    CustomerID = customers.Single(s => s.LastName == "Miller").CustomerID,
                    ProductID = products.Single(c => c.Title == "The 4 Hour Work Week" ).ProductID,
                },
                new Purchase {
                    CustomerID = customers.Single(s => s.LastName == "Monson").CustomerID,
                    ProductID = products.Single(c => c.Title == "Rich Dad, Poor Dad" ).ProductID,
                },
                new Purchase {
                    CustomerID = customers.Single(s => s.LastName == "Young").CustomerID,
                    ProductID = products.Single(c => c.Title == "The Holy Bible" ).ProductID,
                },
                new Purchase {
                    CustomerID = customers.Single(s => s.LastName == "Smith").CustomerID,
                    ProductID = products.Single(c => c.Title == "The Book of Mormon" ).ProductID,
                }
            };

            foreach (Purchase e in purchases)
            {
                var enrollmentInDataBase = context.Purchases.Where(
                    s =>
                         s.Customer.CustomerID == e.CustomerID &&
                         s.Product.ProductID == e.ProductID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Purchases.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
