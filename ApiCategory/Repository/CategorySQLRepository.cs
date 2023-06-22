using ApiCategory.DbContexts;
using ApiCategory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiCategory.Repository
{
    public class CategorySQLRepository : ICategoryRepository
    {
        private AppDbContext dbContext;
        public CategorySQLRepository(AppDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await dbContext.Categories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
            if (category == null)
            {
                throw new Exception("Category not found with id=" + id.ToString());
            }
            return category;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            this.dbContext.Categories.Add(category);
            await this.dbContext.SaveChangesAsync();
            return category;
        }
        public async Task<Category> UpdateCategory(Category category)
        {
            this.dbContext.Categories.Update(category);
            await this.dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var result = await this.dbContext.Categories.FirstOrDefaultAsync(category => category.CategoryId == id);
            if (result != null)
            {
                this.dbContext.Categories.Remove(result);
                await this.dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
