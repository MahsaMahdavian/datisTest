using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConvertLinqApplication.models.Repository;

namespace ConvertLinqApplication.models.UnitOfWork
{
    public interface IUnitOfWork
    {
        DatabaseContext _Context { get; }
      
        IRepositoryBase<TEntity> BaseRepository<TEntity>() where TEntity : class;
        Task Commit();
    }
}
