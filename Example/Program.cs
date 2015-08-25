using System.Data.Entity;
using System.Linq;
using System;
using System.Configuration;


namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connection = ConfigurationManager.AppSettings["SchoolContext"];
            
            using (var ctx = new SchoolContext())
            {
                Student stud = new Student() { StudentName = "Student" };
                ctx.Students.Add(stud);
                
                ctx.SaveChanges();
                Console.WriteLine("Done");
            }
        }
    }
}
