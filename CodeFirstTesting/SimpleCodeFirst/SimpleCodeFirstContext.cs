using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeFirst
{
    public class SimpleCodeFirstContext : DbContext
    {
        public SimpleCodeFirstContext() : base("name=Simple")
        {
        }
        
        public DbSet<ProductOrder> ProductOrder { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<BackupPerson> BackupPerson { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Person>()
                .Map(m =>
                {
                    m.Properties(p => new {p.FirstName, p.LastName});
                    m.ToTable("Person");
                })
                .Map(m =>
                {
                    m.Properties(p => new {p.OverlyLongDescriptionField});
                    m.ToTable("PersonDescription");
                });

            modelBuilder.Entity<ProductOrder>().ToTable("ProductOrder");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<BackupPerson>().ToTable("BackupPerson", "Audit");
        }
    }
}
