using System.ComponentModel.DataAnnotations;

namespace ApiAuthor.Models
{
    public class Book
    {
        [Key]
        public int bookId { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public int numberOfPages { get; set; }
        public int authorId { get; set; }
        public Author? author { get; set; }
    }
}
