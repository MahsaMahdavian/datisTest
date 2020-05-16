using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using ConvertLinqApplication.Filter;
using ConvertLinqApplication.models.Repository;
using Microsoft.EntityFrameworkCore;

namespace ConvertLinqApplication.models
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity> where TEntity:class  where TContext : DbContext
    {
        //protected readonly ApplicationDbContext DbContext;
        protected TContext _Context { get; set; }
        private DbSet<TEntity> dbSet;
        public virtual IQueryable<TEntity> Table => dbSet;
        public virtual IQueryable<TEntity> TableNoTracking => dbSet.AsNoTracking();
        public RepositoryBase(TContext Context)
        {
            _Context = Context;
            dbSet = _Context.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<TEntity> FindByIDAsync(Object id)
        {
            return await dbSet.FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _Context.Set<TEntity>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

       

        public void Update(TEntity entity) => dbSet.Update(entity);
        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            dbSet.Update(entity);
            if (saveNow)
                await _Context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
        public void Delete(TEntity entity) => dbSet.Remove(entity);

        
    }
}
