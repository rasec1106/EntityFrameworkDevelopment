using ApiCategory.Models;
using ApiCategory.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiCategory.Controllers
{
    [ApiController]
    [Route("/api/category")]
    public class CategoryController: ControllerBase
    {
        private ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await categoryRepository.GetCategories();
        }
    }
}
