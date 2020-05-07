using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConvertLinqApplication.models.Repository;

namespace ConvertLinqApplication.models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public DatabaseContext _Context { get; }

        public DatabaseContext Context => throw new NotImplementedException();


        public UnitOfWork(DatabaseContext Context)
        {
            _Context = Context;
        }
   
        public IRepositoryBase<TEntity> BaseRepository<TEntity>() where TEntity : class
        {
            IRepositoryBase<TEntity> repository = new RepositoryBase<TEntity, DatabaseContext>(_Context);
            return repository;
        }
        public async Task Commit()
        {
            await _Context.SaveChangesAsync();
        }
    }
}
