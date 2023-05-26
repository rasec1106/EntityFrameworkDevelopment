using ApiAuthor.DbContexts;
using ApiAuthor.Dtos;
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
        public async Task<ResponseDto> createAuthorWithBooks(Author author)
        {

            ResponseDto response = new ResponseDto();
            try
            {
                dbContext.authors.Add(author);
                await dbContext.SaveChangesAsync();
                response.isError = false;
                response.statusCode= 201;
                response.message = $"Author created correctly with {author.books?.Count.ToString() ?? "no"} books";
            }
            catch(Exception ex)
            {
                response.isError = true;
                response.message = ex.Message;
                response.statusCode = 500;
            }
            return response;
        }
    }
}
