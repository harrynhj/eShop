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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AuthenticationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> GetUserByUsername(string userName)
        {
            return await _DbContext.Users
                .Where(u => u.Username == userName)
                .FirstOrDefaultAsync();
        }

    }
}
