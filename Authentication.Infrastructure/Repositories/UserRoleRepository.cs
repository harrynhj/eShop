using Authentication.ApplicationCore.Entities;
using Authentication.ApplicationCore.Repositories;
using Authentication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(AuthenticationDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<ICollection<UserRole>> GetAllUsersWithRole()
        {
            return await _DbContext.UserRoles
                .Include(ur => ur.User)
                .Include(ur => ur.Role)
                .ToListAsync();
        }

        public async Task<UserRole> GetUserRoleByUserId(int userId)
        {
            return await _DbContext.UserRoles
                .Include(ur => ur.Role)
                .Include(ur => ur.User)
                .FirstOrDefaultAsync(ur => ur.UserId == userId);
        }
    }
}
