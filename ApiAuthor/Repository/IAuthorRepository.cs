using ApiAuthor.Models;

namespace ApiAuthor.Repository
{
    public interface IAuthorRepository
    {
        public Task<bool> createAuthorWithBooks(Author author);
    }
}
