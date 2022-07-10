using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Arq.Spotify.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity obj);
        Task Remove(TEntity obj);
        Task RemoveAll(TEntity[] objs);
        Task<IEnumerable<TEntity>> FindByCriteria<T>(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> FindOneByCriteria<T>(Expression<Func<TEntity, bool>> expression);
    }
}
