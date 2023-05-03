using Microsoft.EntityFrameworkCore;
using MvcFriends.Models;
namespace MvcFriends.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}
        public DbSet<Friends> Friends {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Friends>().HasData(
                new Friends {Id=1, Name="Mary", Email="mary@gmailcom", Mobile="0922-111222"},
                new Friends {Id=2, Name="David", Email="david@gmailcom", Mobile="0933-111222"},
                new Friends {Id=3, Name="Rose", Email="rose@gmailcom", Mobile="0944-111222"}
            );
        }
    }
}