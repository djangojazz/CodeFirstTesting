using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EasyEntity;

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
            */

            using (var context = new EasyContext())
            {
                context.Person.Add(new Person {FirstName = "Brett", LastName = "Test"});
                context.SaveChanges();
                
                var productOrders = context.ProductOrder.Include("Products").ToList();
                var persons = context.Person.ToList();

                persons.GroupJoin(productOrders, 
                    p => p.PersonId, 
                    o => o.Person.PersonId,
                    (p, g) => g
                        .Select(o => new { PersonName = p.FirstName + " " + p.LastName, Orders = o})
                        .DefaultIfEmpty(new { PersonName = p.FirstName + " " + p.LastName, Orders = new ProductOrder() })
                        )
                    .SelectMany(g => g)
                    .ToList()
                    .ForEach(item =>
                    {
                        Console.WriteLine(item.PersonName);

                        if (!(item?.Orders?.Products?.Count > 0))
                            return;

                        Console.WriteLine($"\t {item.Orders.ProductOrderName}");
                        item.Orders.Products.ForEach(x => Console.WriteLine($"\t\t {x.ProductName}"));
                    });
                
                Console.ReadLine();
            }
        }
    }
}
