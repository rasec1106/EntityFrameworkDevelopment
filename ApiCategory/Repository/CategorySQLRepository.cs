using ApiCategory.DbContexts;
using ApiCategory.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCategory.Repository
{
    public class CategorySQLRepository : ICategoryRepository
    {
        private AppDbContext dbContext;
        public CategorySQLRepository(AppDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task<Category> AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await dbContext.Categories.ToListAsync();
        }
    }
}
