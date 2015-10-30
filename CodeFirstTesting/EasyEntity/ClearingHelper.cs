using System.Data.Entity;

namespace EasyEntity
{
    public static class ClearingHelper
    {
        public static bool Extenderer(this int i)
        {
            return true;
        }

        public static void ClearRange<T>(this DbSet<T> dbSet) where T : class
        {
            using (var context = new EasyContext())
            {
                dbSet.RemoveRange(dbSet);
            }
        }

        public static void ResetIdentity(string tableName)
        {
            using (var context = new EasyContext())
            {
                context.Database.ExecuteSqlCommand($"DBCC CHECKIDENT('{tableName}', RESEED, 0)");
            }
        }
    }
}
