namespace EasyEntity.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EasyEntity.EasyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EasyEntity.EasyContext";
            var drop = new DropCreateDatabaseAlways<EasyContext>();
        }

        protected override void Seed(EasyEntity.EasyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Do I want this or not?
            //context.Person.AddOrUpdate(new Person { PersonId = 5, FirstName = "Ken", LastName = "Guernsey" } );
            
            base.Seed(context);
        }
    }
}
