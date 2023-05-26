using ApiAuthor.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAuthor.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }
    }
}
