using ApiAuthor.Models;
using ApiAuthor.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuthor.Controllers
{
    [ApiController]
    [Route("/api/author")]
    public class AuthorController : ControllerBase
    {
        private IAuthorRepository authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        [Route("/createAuthorWithBooks")]
        [HttpPost]
        public async Task<ActionResult<bool>> createAuthorWithBooks(Author author)
        {
            return StatusCode(StatusCodes.Status201Created, await this.authorRepository.createAuthorWithBooks(author));
        }
    }
}
