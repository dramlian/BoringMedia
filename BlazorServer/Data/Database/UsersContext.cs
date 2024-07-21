using BlazorServer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Data.Database
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
        {
        }

        public DbSet<User> BoringMediaUsers { get; set; }
    }
}
