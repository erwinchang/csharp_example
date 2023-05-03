using Microsoft.EntityFrameworkCore;
using MvcFriends.Models;
namespace MvcFriends.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}
        public DbSet<Friends> Friends {get; set;}
    }
}