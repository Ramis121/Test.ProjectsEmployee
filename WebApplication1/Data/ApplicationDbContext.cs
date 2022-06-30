using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT.Projectstwo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } 

        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Employees> Employees { get; set; }
        
    }
}
