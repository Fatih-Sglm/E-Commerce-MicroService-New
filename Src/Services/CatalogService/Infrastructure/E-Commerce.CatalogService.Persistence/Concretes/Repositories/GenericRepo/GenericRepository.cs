using E_Commerce.CatalogService.Application.Abstractions.Repositories.GenericRepo;
using E_Commerce.CatalogService.Application.Exceptions;
using E_Commerce.CatalogService.Application.Extensions;
using E_Commerce.CatalogService.Application.Models.DynamicQuery;
using E_Commerce.CatalogService.Application.Paging;
using E_Commerce.CatalogService.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace E_Commerce.CatalogService.Persistence.Concretes.Repositories.GenericRepo
{
    public class GenericRepository<T, TContext> : IGenericRepository<T> where T : class, IEntity
    where TContext : DbContext
    {
        protected TContext Context { get; }


        public GenericRepository(TContext context)
        {
            Context = context;
        }

        public DbSet<T> Table => Context.Set<T>();

        #region GetAsync
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
                                         IIncludableQueryable<T, object>>? include = null, bool enableTracking = true,
                                         CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = Table.AsQueryable();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);

            var data = await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
            return data is null ? throw new NotFoundException($"{typeof(T).Name} cant found") : data;
        }
        #endregion
        #region GetList
        public async Task<IQueryable<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = Table.AsQueryable();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await Task.FromResult(orderBy(queryable));
            return await Task.FromResult(queryable);
        }


        public async Task<IPaginate<T>> GetListAsyncWithPaginate(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            var queryable = await GetListAsync(predicate, orderBy, include, enableTracking, cancellationToken);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }



        #endregion
        #region GetListDynamic

        public async Task<IQueryable<T>> GetListDynamicAsync(Dynamic dynamic, Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = Table.AsQueryable().ToDynamic(dynamic);
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            return await Task.FromResult(queryable);
        }

        public async Task<IPaginate<T>> GetListDynamicAsyncWithPaginate(Dynamic dynamic, Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            var queryable = await GetListDynamicAsync(dynamic, predicate, include, enableTracking, cancellationToken);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }
        #endregion


        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            Context.Entry(entity).State = EntityState.Added;
        }

        public Task UpdateAsync(T entity)
        {
            Table.Update(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            Table.Remove(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            return Task.CompletedTask;
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().FirstOrDefault(predicate);
        }

        public async Task AddRangeAsync(List<T> values)
        {
            await Context.AddRangeAsync(values);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
