using Microsoft.EntityFrameworkCore;
using Authentication.ApplicationCore.Entities;


namespace Authentication.Infrastructure.Data
{
    public class AuthenticationDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options)
        {

        }
    }
}
