using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // MS SQL TABLE: The table name MUST be Users for mapping the User Model
        public DbSet<User> Users { get; set; }
    }
}