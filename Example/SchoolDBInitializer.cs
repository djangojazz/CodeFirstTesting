using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class SchoolDBInitializer : DropCreateDatabaseAlways<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            new List<Standard>
            {
               new Standard { StandardName = "Standard 1", Description = "First Standard" },
               new Standard { StandardName = "Standard 2", Description = "Second Standard" },
               new Standard { StandardName = "Standard 3", Description = "Third Standard" }
            }.ForEach(x => context.Standards.Add(x));

            new List<Student>
            {
                new Student { StudentName = "Brett", DateOfBirth=new DateTime(1977, 12, 18), StudentKey=1234},
                new Student { StudentName = "Emily", DateOfBirth=new DateTime(1976, 11, 28), StudentKey=4567}
            }.ForEach(x => context.Students.Add(x));

            base.Seed(context);
        }
    }
}
