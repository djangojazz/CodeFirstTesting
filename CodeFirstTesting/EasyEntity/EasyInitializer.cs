using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

namespace EasyEntity
{
    public class EasyInitializer : DropCreateDatabaseAlways<EasyContext>
    {
        protected override void Seed(EasyContext context)
        {
            SeedIt(context);
        }

        public void SeedIt(EasyContext context)
        {
            IList<Person> persons = new List<Person>
            {
                new Person { FirstName = "Brett", LastName = "Morin", OverlyLongDescriptionField = "OMG Look I have a bunch of text denormalizing a table by putting a bunch of stuff only side related to the primary table." },
                new Person { FirstName = "Neil", LastName = "Carpenter"},
                new Person { FirstName = "Ryan", LastName = "Johnson"},
                new Person { FirstName = "Aaron", LastName = "Shaver"},
            };

            foreach (var person in persons)
                context.Person.Add(person);

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
                context.Product.Add(product);

            IList<ProductOrder> productOrders = new List<ProductOrder>
            {
                new ProductOrder {PersonId = 1, ProductOrderName = "BrettOrders", Products = new List<Product> { products[0], products[1], products[2]} },
                new ProductOrder {PersonId = 2, ProductOrderName = "NeilOrders", Products = new List<Product> { products[3], products[4], products[5], products[6] } }
            };

            foreach (var productOrder in productOrders)
                context.ProductOrder.Add(productOrder);
            
            base.Seed(context);
        }
    }
}
