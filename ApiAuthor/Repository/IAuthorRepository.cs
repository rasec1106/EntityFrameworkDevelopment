using ApiAuthor.Dtos;
using ApiAuthor.Models;

namespace ApiAuthor.Repository
{
    public interface IAuthorRepository
    {
        public Task<ResponseDto> createAuthorWithBooks(Author author);
    }
}
