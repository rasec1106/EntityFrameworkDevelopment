using Microsoft.EntityFrameworkCore;
using Test_Practice02_01.Models;

namespace Test_Practice02_01.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ShipDocument> shipDocuments { get; set; }
        public DbSet<ShipDocumentDetail> shipDocumentDetails { get; set; }
    }
}
