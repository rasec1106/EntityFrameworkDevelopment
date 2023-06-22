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

        [Route("/GetCategoryById/{id}")]
        [HttpGet]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await categoryRepository.GetCategoryById(id));
        }

        [Route("/CreateCategory")]
        [HttpPost]
        // ActionResult is inserted to help customize the kind of response we are sending
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            // We wrap it all into StatusCode
            return StatusCode(StatusCodes.Status201Created, await categoryRepository.CreateCategory(category));

        }

        [Route("/UpdateCategory")]
        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory(Category category)
        {
            return StatusCode(StatusCodes.Status200OK, await categoryRepository.UpdateCategory(category));
            /* Another way to do this is */
            //return Ok(await CategoryRepository.UpdateCategory(Category));
        }

        [Route("/DeleteCategory")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCategory(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await categoryRepository.DeleteCategory(id));
        }
    }
}
