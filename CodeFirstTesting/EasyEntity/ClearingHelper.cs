using System.Data.Entity;

namespace EasyEntity
{
    public static class ClearingHelper
    {
        public static bool Extenderer(this int i)
        {
            return true;
        }

        public static void ClearRange<T>(this DbSet<T> dbSet, string tableName, bool reseed = true) where T : class
        {
            using (var context = new EasyContext())
            {
                dbSet.RemoveRange(dbSet);
                if(reseed)
                    context.Database.ExecuteSqlCommand($"DBCC CHECKIDENT('dbo.{tableName}', RESEED, 0)");
                context.SaveChanges();
            }
        }
    }
}
