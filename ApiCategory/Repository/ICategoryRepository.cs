using ApiCategory.Models;

namespace ApiCategory.Repository
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetCategories();
        public Task<Category> AddCategory(Category category);

    }
}
