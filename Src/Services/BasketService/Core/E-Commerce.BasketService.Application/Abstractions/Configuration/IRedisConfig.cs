using StackExchange.Redis;

namespace E_Commerce.BasketService.Application.Abstractions.Configuration
{
    public interface IRedisConfig
    {
        IDatabase GetRedisDatabase();
        IServer GetServer();
    }
}
