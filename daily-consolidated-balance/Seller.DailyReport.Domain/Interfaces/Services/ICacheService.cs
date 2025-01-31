namespace Seller.DailyReport.Domain.Interfaces.Services
{
    public interface ICacheService
    {
        T? GetByKey<T>(string key);
        void Save(string key, object data);
    }
}
