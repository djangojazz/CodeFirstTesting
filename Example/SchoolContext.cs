using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace Example
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("CodeFirst")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolContext, Example.Migrations.Configuration>("SchoolContext"));
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<StudentAddress> StudentAddress { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Moved all Student related configuration to StudentEntityConfiguration class
            modelBuilder.Configurations.Add(new StudentEntityConfiguration());
        }
    }

}
