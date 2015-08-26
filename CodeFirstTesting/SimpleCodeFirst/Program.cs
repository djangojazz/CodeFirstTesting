using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeFirst
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

            using (var context = new SimpleCodeFirstContext())
            {
                Person person = new Person {FirstName = "Brett", LastName = "Morin"};
                
                context.Person.Add(person);
                context.SaveChanges();
            }
        }
    }
}
