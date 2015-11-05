using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EasyEntity
{
    public class EasyContext : DbContext
    {
        public EasyContext() : base("name=EasyEntity")
        {
            //These should be set up now in the config files more on this here: https://msdn.microsoft.com/en-us/data/jj556606.aspx
            //Database.SetInitializer<EasyContext>(new CreateDatabaseIfNotExists<EasyContext>());
            //Database.SetInitializer<EasyContext>(new DropCreateDatabaseIfModelChanges<EasyContext>());
            //Database.SetInitializer<EasyContext>(new DropCreateDatabaseAlways<EasyContext>());
            //Database.SetInitializer<EasyContext>(new EasyInitializer());

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<EasyContext, Migrations.Configuration>("EasyEntity"));
        }

        public DbSet<ProductOrder> ProductOrder { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Audit>  Backup { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<ProductOrder>()
                .HasMany(p => p.Products)
                .WithMany(po => po.ProductOrders)
                .Map(pop =>
                {
                    pop.MapLeftKey("ProductOrderId");
                    pop.MapRightKey("ProductId");
                    pop.ToTable("ProductOrder_Product_Mapping");
                });

            //TODO V3: Let's normalize out a long descriptive field.
            //Asked question on Stack Overflow on this.  Amazing feature, I am ignorant of how to do seeding without a database drop first. 
            //modelBuilder.Entity<Person>()
            //.Map(m =>
            //{
            //    m.Properties(p => new { p.PersonId, p.FirstName, p.LastName });
            //    m.ToTable("Person");
            //})
            //.Map(m =>
            //{
            //    m.Properties(p => new { p.PersonId, p.OverlyLongDescriptionField });
            //    m.ToTable("PersonDescription");
            //});

            //TODO V4: name table better
            //modelBuilder.Entity<Audit>()
            //.Map(m =>
            //{
            //    m.Properties(p => new { p.AuditId, p.xmlBlob });
            //    m.ToTable("AuditTable", "Audit");
            //});
        }
    }
}
