using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace FunFox.PortalSystem.Common.Extensions
{
    public static class RepositoryExtensions
    {
        public static IQueryable<TEntity>? Include<TEntity>(this DbSet<TEntity>? dbSet,
            params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class
        {
            IQueryable<TEntity>? query = null;
            foreach (var include in includes)
            {
                query = dbSet.Include(include);
            }

            return query ?? dbSet;
        }

        public static TEntity SingeOrDefault<TEntity>(this DbSet<TEntity> dbSet,
            Expression<Func<TEntity, bool>> condition)
            where TEntity : class
        {
            return dbSet.SingleOrDefault(condition) ?? throw new InvalidOperationException();
        }

        public static async Task<TEntity> SingeOrDefaultAsync<TEntity>(this DbSet<TEntity> dbSet,
            Expression<Func<TEntity, bool>> condition)
            where TEntity : class
        {
            return await dbSet.SingleOrDefaultAsync(condition) ?? throw new InvalidOperationException();
        }
    }
}
