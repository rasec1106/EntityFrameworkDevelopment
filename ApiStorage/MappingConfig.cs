using ApiStorage.DTOs;
using ApiStorage.Models;
using AutoMapper;
using System;

namespace ApiStorage
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // We are creating a two way transformation
                config.CreateMap<StorageDto, Storage>();
                config.CreateMap<Storage, StorageDto>();
            });
            return mappingConfig;
        }
    }
}
