using ApiCategory.Models;

namespace ApiCategory.Repository
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetCategories();
        public Task<Category> GetCategoryById(int id);
        public Task<Category> CreateCategory(Category category);
        public Task<Category> UpdateCategory(Category category);
        public Task<bool> DeleteCategory(int id);

    }
}
