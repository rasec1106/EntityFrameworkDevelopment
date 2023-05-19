using ApiStorage.DTOs;
using ApiStorage.Models;
namespace ApiStorage.Repository
{
    public interface IStorageRepository
    {
        Task<IEnumerable<StorageDto>> GetStorages();
        Task<StorageDto> GetStorageById(int id);
        Task<StorageDto> CreateStorage(Storage storage);
        Task<StorageDto> UpdateStorage(Storage storage);
        Task<bool> DeleteStorage(int id);
    }
}
