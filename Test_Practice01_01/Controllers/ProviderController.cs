using Microsoft.AspNetCore.Mvc;
using Test_Practice01_01.Models;
using Test_Practice01_01.Repository;

namespace Test_Practice01_01.Controllers
{
    [ApiController]
    [Route("/api/provider")]
    public class ProviderController : ControllerBase
    {
        private IProviderRepository providerRepository;

        public ProviderController(IProviderRepository providerRepository)
        {
            this.providerRepository = providerRepository;
        }

        [Route("/GetProviders")]
        [HttpGet]
        public async Task<IEnumerable<MyProvider>> GetProviders()
        {
            return await providerRepository.GetProviders();
        }

        [Route("/GetProviderById/{id}")]
        [HttpGet]
        public async Task<MyProvider> GetProviderById(int id)
        {
            return await providerRepository.GetProviderById(id);
        }

        [Route("/CreateProvider")]
        [HttpPost]
        public async Task<MyProvider> CreateProvider(MyProvider provider)
        {
            return await providerRepository.CreateProvider(provider);
        }

        [Route("/UpdateProvider")]
        [HttpPut]
        public async Task<MyProvider> UpdateProvider(MyProvider provider)
        {
            return await providerRepository.UpdateProvider(provider);
        }

        [Route("/DeleteProvider")]
        [HttpDelete]
        public async Task<bool> DeleteProvider(int id)
        {
            return await providerRepository.DeleteProvider(id);
        }
    }
}
