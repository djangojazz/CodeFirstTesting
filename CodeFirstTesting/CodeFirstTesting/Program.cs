using System;
using System.Linq;
using EasyEntity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Metadata.Edm;
using System.Reflection;

namespace CodeFirstTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            SQL FOR REFERENCE 

            USE SimpleCodeFirst;

            IF Object_id('ProductOrder') IS NOT NULL
                DROP TABLE ProductOrder

            IF Object_id('Product') IS NOT NULL
                DROP TABLE Product
            
            IF Object_id('Person') IS NOT NULL
                DROP TABLE Person
            
            CREATE TABLE Person
            (
                PersonId    int identity    CONSTRAINT PK_PersonId PRIMARY Key
            ,   FirstName   varchar(256)    NOT NULL
            ,   LastName    varchar(256)    NOT NULL
            )
            
            CREATE TABLE ProductOrder
            (
                ProductOrderId  int identity    NOT NULL CONSTRAINT PK_ProductOrderId PRIMARY Key
            ,   PersonId        int             CONSTRAINT FK_ProductOrder_PersonId FOREIGN Key(PersonId) REFERENCES Person(PersonId)
            ,   OrderName       varchar(256)    NOT NULL
            )

            CREATE TABLE Product
            (
                ProductId   int IDENTITY    CONSTRAINT  PK_ProductId PRIMARY Key
            ,   OrderId     int             CONSTRAINT FK_Product_OrderId FOREIGN Key(OrderId) REFERENCES Order(OrderId)
            ,   ProductName varchar(256)    NOT NULL
            )
            
            INSERT INTO dbo.Person(FirstName, LastName) VALUES('Bart', 'Simpson'),('Lisa', 'Simpson');
            INSERT INTO dbo.ProductOrder(PersonId, OrderName) VALUES (1, 'Clothing'),(2, 'Clothing'),(1, 'SpareTime');
            INSERT INTO dbo.Product(OrderId, ProductName) VALUES(1, 'Shirt'),(1, 'Shoes'),(1, 'Shorts'),(1, 'Hat'),(2, 'Dress'),(2, 'Bow'),(3, 'SkateBoard');

            Select
                p.FirstName + ' ' + p.LastName AS Name
            , po.OfficeName
            ,	o.ProductName
            from dbo.Person p
                left JOIN dbo.Order o ON o.PersonId = p.PersonId
                left JOIN dbo.Product po ON po.OrderId = o.OrderId

            TO ENABLE AUTOMATIC MIGRATION:
            First, open the package manager console from Tools → Library Package Manager → Package Manager Console and then 
            run "enable-migrations –EnableAutomaticMigration:$true" command 
            (make sure that the default project is the project where your context class is)

            TO ENABLE ADD MIGRATION:
            First, open the package manager console from Tools → Library Package Manager → Package Manager Console and then 
            run "add-migration "First Easy schema"" or similar.

            UPDATE DATABASE AFTER MIGRATION:
            First, open the package manager console from Tools → Library Package Manager → Package Manager Console and then 
            run "update-database -verbose".  The verbose switch will show the SQL Statements that run as well.

            FORCE DATABASE FORCE:
            
            */

            using (var context = new EasyContext())
            {
                //var people = context.Person.ToList();
                
                //people.ForEach(x => Console.WriteLine($"{x.PersonId} {x.FirstName} {x.OverlyLongDescriptionField}"));

                var productOrders = context.ProductOrder.Include("Products").ToList();
                var persons = context.Person.ToList();

                persons.GroupJoin(productOrders,
                    p => p.PersonId,
                    o => o.Person.PersonId,
                    (p, g) => g
                        .Select(o => new { PersonId = p.PersonId, PersonName = p.FirstName + " " + p.LastName, p.OverlyLongDescriptionField, Orders = o })
                        .DefaultIfEmpty(new { PersonId = p.PersonId, PersonName = p.FirstName + " " + p.LastName, p.OverlyLongDescriptionField, Orders = new ProductOrder() })
                        )
                    .SelectMany(g => g)
                    .ToList()
                    .ForEach(item =>
                    {
                        Console.WriteLine($"{item.PersonId}: {item.PersonName}: {item.OverlyLongDescriptionField}");

                        if (!(item?.Orders?.Products?.Count > 0))
                            return;

                        Console.WriteLine($"\t {item.Orders.ProductOrderId}: {item.Orders.ProductOrderName}");
                        item.Orders.Products.ToList().ForEach(x => Console.WriteLine($"\t\t{x.ProductId}: {x.ProductName}"));
                    });

                Console.ReadLine();
            }
        }
    }
}
