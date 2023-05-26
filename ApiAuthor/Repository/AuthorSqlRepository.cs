using ApiAuthor.DbContexts;
using ApiAuthor.Models;
using System;
namespace ApiAuthor.Repository
{
    public class AuthorSqlRepository : IAuthorRepository
    {
        private AppDbContext dbContext;
        public AuthorSqlRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> createAuthorWithBooks(Author author)
        {
            try
            {
                /* some validations before saving */
                // 1. When saving the books, they are supposed to belong to the same author

                dbContext.authors.Add(author);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
