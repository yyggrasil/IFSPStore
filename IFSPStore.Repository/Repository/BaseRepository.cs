using IFSPStore.Domain.Base;
using IFSPStore.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IFSPStore.Repository.Repository
{
    public class BaseRepository<TEntity>
        : IBaseRepository<TEntity> where TEntity
        : BaseEntity<int>
    {
        protected readonly MySqlContext _mySqlcontext;

        public void AtachObject(object obj)
        {
            throw new NotImplementedException();
        }

        public void ClearChangeTracker()
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            _mySqlcontext.Set<TEntity>().Remove(Select(id));
        }

        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> Select(IList<string>? includes = null)
        {
            var dbContext = _mySqlcontext.Set<TEntity>().AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    dbContext = dbContext.Include(include);
                }
            }
            return dbContext.ToList();
        }

        public TEntity Select(object id, IList<string>? includes = null)
        {
            var dbContext = _mySqlcontext.Set<TEntity>().AsQueryable();
            if (includes != null)
            {
                foreach(var include in includes)
                {
                    dbContext = dbContext.Include(include);
                }
            }
            return dbContext.ToList().Find(x => x.Id == (int)id);
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
