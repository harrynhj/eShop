

using Authentication.ApplicationCore.Models;

namespace Authentication.ApplicationCore.Services
{
    public interface IAuthenticationService
    {
        public Task<UserViewModel> Login(LoginModel model);
        public Task<UserViewModel> CustomerRegister(CustomerRegisterModel model);
        public Task<bool> UpdateAccount(UpdateModel model);
        public Task<bool> DeleteAccount(int id);
        public Task<List<UserViewModel>> GetAllUsers();
        public Task<UserViewModel> AdminRegister(CustomerRegisterModel model);
        public Task<UserViewModel> GetUserById(int id);
    }
}
