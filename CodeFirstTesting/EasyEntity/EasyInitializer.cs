using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

namespace EasyEntity
{
    public class EasyInitializer : DropCreateDatabaseAlways<EasyContext>
    {
        protected override void Seed(EasyContext context)
        {
            SeedIt(context);
        }

        public void SeedIt(EasyContext context)
        {
            SeedingValues.SeedingForDatabaseDrop(context);
            
            base.Seed(context);
        }
    }
}
