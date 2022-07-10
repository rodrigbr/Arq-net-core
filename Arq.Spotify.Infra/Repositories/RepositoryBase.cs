using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Arq.Spotify.Domain.Contracts.Repositories;
using Arq.Spotify.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Arq.Spotify.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly SpotifyContext Context;

        public RepositoryBase(SpotifyContext context)
        {
            Context = context;
        }

        public async Task Add(TEntity obj)
        {
            await Context.Set<TEntity>().AddAsync(obj);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Task.FromResult(Context.Set<TEntity>().AsEnumerable());
        }

        public async Task Update(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task Remove(TEntity obj)
        {
            Context.Set<TEntity>().Remove(obj);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAll(TEntity[] objs)
        {
            Context.Set<TEntity>().RemoveRange(objs);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> FindByCriteria<T>(Expression<Func<TEntity, bool>> expression)
        {
            return await Task.FromResult(Context.Set<TEntity>().Where(expression));
        }

        public async Task<TEntity> FindOneByCriteria<T>(Expression<Func<TEntity, bool>> expression)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public void Dispose()
        {

        }
    }
}
