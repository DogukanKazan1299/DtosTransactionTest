using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var context = new TContext())
            {
                var deletedEntity = await context.Set<TEntity>().FindAsync(id);
                context.Set<TEntity>().Remove(deletedEntity);
                var data = await context.SaveChangesAsync();
                if (data > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        

        public async Task<TEntity> Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        async Task<List<TEntity>> IEntityRepositoryBase<TEntity>.GetListAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return filter == null ?
                    await context.Set<TEntity>().ToListAsync() : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }
    }
}
