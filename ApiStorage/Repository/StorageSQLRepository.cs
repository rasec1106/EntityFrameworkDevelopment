using ApiStorage.DTOs;
using ApiStorage.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiStorage.Repository
{
    public class StorageSQLRepository : IStorageRepository
    {
        private ApiStorageContext dbContext;
        private IMapper mapper;
        public StorageSQLRepository(ApiStorageContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<StorageDto> CreateStorage(Storage storage)
        {
            this.dbContext.Storages.Add(storage);
            await this.dbContext.SaveChangesAsync();
            return this.mapper.Map<StorageDto>(storage);
        }

        public async Task<bool> DeleteStorage(int id)
        {
            var result = await this.dbContext.Storages.FirstOrDefaultAsync(storage => storage.StorageId == id);
            if (result != null)
            {
                this.dbContext.Storages.Remove(result);
                await this.dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<StorageDto> GetStorageById(int id)
        {
            Storage storage = await this.dbContext.Storages.Where(storage => storage.StorageId == id).FirstOrDefaultAsync();
            return this.mapper.Map<StorageDto>(storage);
        }

        public async Task<IEnumerable<StorageDto>> GetStorages()
        {
            List<Storage> storages = await this.dbContext.Storages.ToListAsync();
            return this.mapper.Map<List<StorageDto>>(storages);
        }

        public async Task<StorageDto> UpdateStorage(Storage storage)
        {
            this.dbContext.Storages.Update(storage);
            await this.dbContext.SaveChangesAsync();
            return this.mapper.Map<StorageDto>(storage);
        }
    }
}
