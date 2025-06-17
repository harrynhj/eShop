using Authentication.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.ApplicationCore.Repositories
{
    public interface IUserRoleRepository : IBaseRepository<UserRole>
    {
        public Task<ICollection<UserRole>> GetAllUsersWithRole();
        public Task<UserRole> GetUserRoleByUserId(int userId);

    }
}
