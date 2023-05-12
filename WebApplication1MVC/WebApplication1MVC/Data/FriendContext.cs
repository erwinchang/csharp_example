using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1MVC.Models;

namespace WebApplication1MVC.Data
{
    public class FriendContext : DbContext
    {
        public FriendContext (DbContextOptions<FriendContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1MVC.Models.Friend> Friend { get; set; }
    }
}
