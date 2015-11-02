using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EasyEntity
{
    public class EasyContext : DbContext
    {
        public EasyContext() : base("name=EasyEntity")
        {
            //Database.SetInitializer<EasyContext>(new CreateDatabaseIfNotExists<EasyContext>());
            //Database.SetInitializer<EasyContext>(new DropCreateDatabaseIfModelChanges<EasyContext>());
            //Database.SetInitializer<EasyContext>(new DropCreateDatabaseAlways<EasyContext>());
            //Database.SetInitializer<EasyContext>(new EasyInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EasyContext, Migrations.Configuration>("EasyEntity"));
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

            //TODO V3 Let's normalize out a long descriptive field
            //modelBuilder.Entity<Person>()
            //.Map(m =>
            //{
            //    m.Properties(p => new { p.FirstName, p.LastName });
            //    m.ToTable("Person");
            //})
            //.Map(m =>
            //{
            //    m.Properties(p => new { p.OverlyLongDescriptionField });
            //    m.ToTable("PersonDescription");
            //});

            //.Property(p => p.PersonId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //TODO V4 name table better
            //modelBuilder.Entity<Audit>()
            //.Map(m =>
            //{
            //    m.Properties(p => new {p.AuditId, p.xmlBlob});
            //    m.ToTable("AuditTable", "Audit");
            //});
        }
    }
}
