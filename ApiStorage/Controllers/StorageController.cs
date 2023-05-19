using Microsoft.AspNetCore.Mvc;
using ApiStorage.Models;
using ApiStorage.DTOs;
using ApiStorage.Repository;
namespace ApiStorage.Controllers
{
    public class StorageController
    {
        private IStorageRepository storageRepository;

        public StorageController(IStorageRepository storageRepository)
        {
            this.storageRepository = storageRepository;
        }

        [Route("/GetStorages")]
        [HttpGet]
        public async Task<IEnumerable<StorageDto>> GetStorages()
        {
            return await storageRepository.GetStorages();
        }

        [Route("/GetStorageById/{id}")]
        [HttpGet]
        public async Task<StorageDto> GetStorageById(int id)
        {
            return await storageRepository.GetStorageById(id);
        }

        [Route("/CreateStorage")]
        [HttpPost]
        public async Task<StorageDto> CreateStorage(Storage storage)
        {
            return await storageRepository.CreateStorage(storage);
        }

        [Route("/UpdateStorage")]
        [HttpPut]
        public async Task<StorageDto> UpdateStorage(Storage storage)
        {
            return await storageRepository.UpdateStorage(storage);
        }

        [Route("/DeleteStorage")]
        [HttpDelete]
        public async Task<bool> DeleteStorage(int id)
        {
            return await storageRepository.DeleteStorage(id);
        }
    }
}
