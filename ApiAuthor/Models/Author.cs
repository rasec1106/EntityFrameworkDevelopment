namespace ApiAuthor.Models
{
    public class Author
    {
        public int authorId { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public int age { get; set; }
        public ICollection<Book>? books { get; set; }

    }
}
