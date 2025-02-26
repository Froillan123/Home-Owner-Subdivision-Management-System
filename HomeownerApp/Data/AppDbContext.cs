// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using HomeownerApp.Models; // Add this namespace to reference the User model

namespace HomeownerApp.Data // Add a namespace for the Data folder
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}