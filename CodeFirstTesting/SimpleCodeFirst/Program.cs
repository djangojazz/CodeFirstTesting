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

            IF Object_id('Product') IS NOT NULL
                DROP TABLE Product
            
            IF Object_id('Person') IS NOT NULL
                DROP TABLE Person
            
            IF Object_id('Office') IS NOT NULL
                DROP TABLE Office
            
            CREATE TABLE Office
                (
                    OfficeId        int identity    Not null CONSTRAINT PK_ProductOfficeId PRIMARY Key
                , OfficeName  varchar(256)    NOT NULL
                )
            
            CREATE TABLE Person
                (
                    PersonId    int identity    CONSTRAINT PK_PersonId PRIMARY Key
                , FirstName   varchar(256)    NOT null
                , LastName    varchar(256)    NOT NULL
                )
            
            CREATE TABLE Product
                (
                    ProductId   int IDENTITY    CONSTRAINT  PK_ProductId PRIMARY Key
                , PersonId    int             CONSTRAINT FK_Product_PersonId FOREIGN Key(PersonId) REFERENCES Person(PersonId)
                , OfficeId    int         CONSTRAINT FK_Product_OfficeId FOREIGN Key(OfficeId) REFERENCES Office(OfficeId)
                , ProductName varchar(256)    NOT null
                )
            
            INSERT INTO dbo.Office(OfficeName) VALUES('Simpsons House'), ('SpringfieldElementary');
            INSERT INTO dbo.Person(FirstName, LastName) VALUES('Bart', 'Simpson'),('Lisa', 'Simpson');
            INSERT INTO dbo.Product(PersonId, OfficeId, ProductName) VALUES(1, 1, 'Shirt'), (2, 1, 'Bow'),(1,2, 'Skateboard'),(2,2,'Sax')

            Select
                p.FirstName + ' ' + p.LastName AS Name
            , po.OfficeName
            ,	o.ProductName
            from dbo.Person p
                left JOIN dbo.Product o ON o.PersonId = p.PersonId
                left JOIN dbo.Office po ON o.OfficeId = po.OfficeId
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
