using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ConvertLinqApplication.models.Repository
{
    public interface IRepositoryBase<TEntity>
    {
        Task<IEnumerable<TEntity>> FindAllAsync();
        Task<TEntity> FindByIDAsync(Object id);
        Task<IEnumerable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
