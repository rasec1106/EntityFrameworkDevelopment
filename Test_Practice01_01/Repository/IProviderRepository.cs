using Test_Practice01_01.Models;
namespace Test_Practice01_01.Repository
{
    public interface IProviderRepository
    {
        Task<IEnumerable<MyProvider>> GetProviders();
        Task<MyProvider> GetProviderById(int id);
        Task<MyProvider> CreateProvider(MyProvider provider);
        Task<MyProvider> UpdateProvider(MyProvider provider);
        Task<bool> DeleteProvider(int id);
    }
}
