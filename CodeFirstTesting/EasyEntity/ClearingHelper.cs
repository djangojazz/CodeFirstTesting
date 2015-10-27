using System.Data.Entity;

namespace EasyEntity
{
    public static class ClearingHelper
    {
        public static bool Extenderer(this int i)
        {
            return true;
        }

        public static void ClearRange<T>(this DbSet<T> dbSet, string tableName) where T : class
        {
            using (var context = new EasyContext())
            {
                dbSet.RemoveRange(dbSet);
                context.Database.ExecuteSqlCommand($"DBCC CHECKIDENT('dbo.{tableName}', RESEED, 1)");
            }
        }
    }
}
