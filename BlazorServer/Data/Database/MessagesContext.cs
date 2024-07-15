using BlazorServer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Data.Database
{
    public class MessagesContext : DbContext
    {
        public MessagesContext(DbContextOptions<MessagesContext> options)
            : base(options)
        {
        }

        public DbSet<Message> UserMessages { get; set; }
    }
}
