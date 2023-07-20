namespace E_Commerce.OrderService.Domain.SeedWork
{
    public interface IRepository
    {
        public IUnitOfWork UnitOfWork { get; }
    }
}
