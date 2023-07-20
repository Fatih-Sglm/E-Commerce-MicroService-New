using E_Commerce.IdentityService.Application.Abstractions.Repositories.Common;
using E_Commerce.IdentityService.Domain;
using E_Commerce.IdentityService.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace E_Commerce.IdentityService.Persistence.Concretes.Repositories.GenericRepo
{
    public class GenericRepoitory<T> : IGenericRepository<T>
    where T : class, IEntity
    {
        protected IdentityContext Context { get; }

        public GenericRepoitory(IdentityContext context)
        {
            Context = context;
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            IQueryable<T> queryable = Query();
            if (include != null) queryable = include(queryable);
            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> Query()
        {
            return Context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().FirstOrDefault(predicate);
        }

        public async Task AddRangeAsync(List<T> datas)
        {
            await Context.AddRangeAsync(datas);
            await Context.SaveChangesAsync();
        }
    }
}
