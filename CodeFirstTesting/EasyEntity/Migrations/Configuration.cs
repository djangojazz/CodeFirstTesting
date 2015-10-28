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
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "EasyEntity.EasyContext";
        }

        protected override void Seed(EasyContext context)
        {
            SeedingValues.SeedingWithoutDatabaseDrop(context);

            base.Seed(context);
        }
    }
}
