using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEntity
{
    internal static class SeedingValues
    {
        public static void SeedingForDatabaseDrop(EasyContext context)
        {
            BaseSeed(context);
        }

        public static void SeedingWithoutDatabaseDrop(EasyContext context)
        {
            context.ProductOrder.ClearRange("ProductOrder");
            context.Product.ClearRange("Product");
            context.Person.ClearRange("Person");

            BaseSeed(context);
        }

        private static void BaseSeed(EasyContext context)
        {

            IList<Person> persons = new List<Person>
            {
                new Person { FirstName = "Brett", LastName = "Morin", OverlyLongDescriptionField = "OMG Look I have a bunch of text denormalizing a table by putting a bunch of stuff only side related to the primary table." },
                new Person { FirstName = "Neil", LastName = "Carpenter"},
                new Person { FirstName = "Ryan", LastName = "Johnson"},
                new Person { FirstName = "Aaron", LastName = "Shaver"},
            };

            foreach (var person in persons)
                context.Person.AddOrUpdate(person);

            IList<Product> products = new List<Product>
            {
                new Product {ProductName = "Shirt"},
                new Product {ProductName = "Pants"},
                new Product {ProductName = "Shoes" },
                new Product {ProductName = "Bike" },

                //TODO V2 normalize this out for many to many relationship
                new Product {ProductName = "Shirt"},
                new Product {ProductName = "Pants"},
                new Product {ProductName = "Shoes" },
            };

            foreach (var product in products)
                context.Product.AddOrUpdate(product);

            IList<ProductOrder> productOrders = new List<ProductOrder>
            {
                //TODO V1 inserts for one to one
                new ProductOrder {Person = persons[0], ProductOrderName = "BrettOrders", Products = new List<Product> { products[0], products[1], products[2]} },
                new ProductOrder {Person = persons[1], ProductOrderName = "NeilOrders", Products = new List<Product> { products[3], products[4], products[5], products[6] } }

                //TODO V2 Inserts for many to many
                //new ProductOrder { Person = persons[0], ProductOrderName = "BrettOrders", Products = new List<Product> { products[0], products[1], products[2]} },
                //new ProductOrder { Person = persons[1], ProductOrderName = "NeilOrders", Products = new List<Product> { products[0], products[1], products[2], products[3] } }
            };

            foreach (var productOrder in productOrders)
                context.ProductOrder.AddOrUpdate(productOrder);
        }
    }
}
