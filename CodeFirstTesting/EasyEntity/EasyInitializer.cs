using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEntity
{
    public class EasyInitializer : DropCreateDatabaseAlways<EasyContext>
    {
        public EasyInitializer(EasyContext context) 
        {
            SeedIt(context);
        }

        public EasyInitializer()
        {
            
        }

        protected override void Seed(EasyContext context)
        {
            SeedIt(context);
        }

        public void SeedIt(EasyContext context)
        {
            IList<Person> persons = new List<Person>
            {
                new Person { FirstName = "Brett", LastName = "Morin", OverlyLongDescriptionField = "OMG Look I have a bunch of text denormalizing a table by putting a bunch of stuff only side related to the primary table."},
                new Person { FirstName = "Neil", LastName = "Carpenter"},
                new Person { FirstName = "Ryan", LastName = "Johnson"},
                new Person { FirstName = "Aaron", LastName = "Shaver"},
            };

            foreach (var person in persons)
                context.Person.Add(person);

            base.Seed(context);
        }
    }
}
