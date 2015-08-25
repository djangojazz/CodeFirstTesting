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
            using (var context = new SimpleCodeFirstContext())
            {
                Person person = new Person {FirstName = "Brett", LastName = "Morin"};
                
                context.Person.Add(person);
                context.SaveChanges();
            }
        }
    }
}
