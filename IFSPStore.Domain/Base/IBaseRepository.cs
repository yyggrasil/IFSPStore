using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Domain.Base
{
    public interface IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        void ClearChangeTracker();
        void AtachObject(object obj);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
        IList<TEntity> Select(IList<string>? includes = null);
        TEntity Select(object id, IList<string>? includes = null);
    }
}
