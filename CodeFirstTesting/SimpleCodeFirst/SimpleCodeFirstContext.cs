using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeFirst
{
    public class SimpleCodeFirstContext : DbContext
    {
        public SimpleCodeFirstContext() : base("SimpleCodeFirst")
        {
        }

        public DbSet<ProductOrder> Office { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
