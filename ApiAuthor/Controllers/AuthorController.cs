using ApiAuthor.Models;
using ApiAuthor.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuthor.Controllers
{
    [ApiController]
    [Route("/api/author")]
    public class AuthorController 
    {
        private IAuthorRepository authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        [Route("/createAuthorWithBooks")]
        [HttpPost]
        public async Task<bool> createAuthorWithBooks(Author author)
        {
            return await this.authorRepository.createAuthorWithBooks(author);
        }
    }
}
