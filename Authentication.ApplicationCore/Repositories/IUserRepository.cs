using Authentication.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.ApplicationCore.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<User> GetUserByUsername(string userName);
    }
}
