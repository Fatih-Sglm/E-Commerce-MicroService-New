using E_Commerce.OrderService.Application.Models.Paging;
using E_Commerce.OrderService.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace E_Commerce.OrderService.Application.Abstractions.Repostories.GenericRepo
{
    public interface IGenericRepository<T> : IRepository where T : BaseEntity
    {
        DbSet<T> Table { get; }
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
                                        IIncludableQueryable<T, object>>? include = null, bool enableTracking = true,
                                        CancellationToken cancellationToken = default);

        Task<IQueryable<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                        bool enableTracking = true,
                                        CancellationToken cancellationToken = default);

        //Task<IQueryable<T>> GetListDynamicAsync(Dynamic dynamic, Func<IQueryable<T>,
        //                                          IIncludableQueryable<T, object>>? include = null,
        //                                          bool enableTracking = true,
        //                                          CancellationToken cancellationToken = default);



        Task<IPaginate<T>> GetListAsyncWithPaginate(Expression<Func<T, bool>>? predicate = null,
                                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                                    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                    int index = 0, int size = 10, bool enableTracking = true,
                                                    CancellationToken cancellationToken = default);


        //Task<IPaginate<T>> GetListDynamicAsyncWithPaginate(Dynamic dynamic,
        //                                                     Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        //                                                     int index = 0, int size = 10, bool enableTracking = true,
        //                                                     CancellationToken cancellationToken = default);
        Task<bool> AddAsync(T entity);


        Task<bool> SaveChangesAsync();
        Task AddRangeAsync(List<T> datas);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
