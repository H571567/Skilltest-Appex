using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<company> companies { get; set; }
        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<RefreshToken> refreshTokens { get; set; }

        
    }
}
