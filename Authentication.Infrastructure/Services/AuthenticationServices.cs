using Authentication.ApplicationCore.Entities;
using Authentication.ApplicationCore.Models;
using Authentication.ApplicationCore.Services;
using Authentication.ApplicationCore.Repositories;
using JwtAuthentcationManager;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Authentication.Infrastructure.Services
{
    public class AuthenticationServices : IAuthenticationService
    {

        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public AuthenticationServices(IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }

        public async Task<UserViewModel> AdminRegister(CustomerRegisterModel model)
        {
            var salt = PasswordHelper.GenerateSalt();
            User newUser = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username =PasswordHelper.HashPassword(model.Password, salt),
                EmailId = model.EmailId,
                Password = model.Password,
                salt = salt
            };
            var userRes = await _userRepository.Insert(newUser);

            UserRole newUserRole = new UserRole
            {
                UserId = userRes.Id,
                RoleId = 1 
            };
            var roleRes = await _userRoleRepository.Insert(newUserRole);
            return new UserViewModel {
                Id = userRes.Id,
                FirstName = userRes.FirstName,
                LastName = userRes.LastName,
                EmailId = userRes.EmailId,
                UserName = userRes.Username,
                Role = "Admin"
            };
            
        }

        public async Task<UserViewModel> CustomerRegister(CustomerRegisterModel model)
        {
            var salt = PasswordHelper.GenerateSalt();
            User newUser = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = PasswordHelper.HashPassword(model.Password, salt),
                EmailId = model.EmailId,
                Password = model.Password,
                salt = salt
            };
            var userRes = await _userRepository.Insert(newUser);

            UserRole newUserRole = new UserRole
            {
                UserId = userRes.Id,
                RoleId = 2
            };
            var roleRes = await _userRoleRepository.Insert(newUserRole);
            return new UserViewModel
            {
                Id = userRes.Id,
                FirstName = userRes.FirstName,
                LastName = userRes.LastName,
                EmailId = userRes.EmailId,
                UserName = userRes.Username,
                Role = "User"
            };
        }

        public async Task<bool> DeleteAccount(int id)
        {
            return await _userRepository.DeleteById(id) != null;
        }

        public async Task<List<UserViewModel>> GetAllUsers()
        {
            var res = await _userRoleRepository.GetAllUsersWithRole();
            if (res == null || !res.Any())
            {
                return new List<UserViewModel>();
            }
            return res.Select(user => new UserViewModel
            {
                Id = user.UserId,
                FirstName = user.User.FirstName,
                LastName = user.User.LastName,
                EmailId = user.User.EmailId,
                UserName = user.User.Username,
                Role = user.Role.Name
            }).ToList();

        }

        public async Task<UserViewModel> GetUserById(int id)
        {
            var res = await _userRoleRepository.GetUserRoleByUserId(id);
            if (res == null)
            {
                return null;
            }
            return new UserViewModel
            {
                Id = res.UserId,
                FirstName = res.User.FirstName,
                LastName = res.User.LastName,
                EmailId = res.User.EmailId,
                UserName = res.User.Username,
                Role = res.Role.Name
            };
        }

        public async Task<UserViewModel> Login(LoginModel model)
        {
            var user = await _userRepository.GetUserByUsername(model.UserName);
            if (user == null)
            {
                return null;
            }
            var hashedPassword = PasswordHelper.HashPassword(model.Password, user.salt);
            if (hashedPassword != user.Password)
            {
                return null;
            }
            var res = await _userRoleRepository.GetUserRoleByUserId(user.Id);
            return new UserViewModel
            {
                Id = res.UserId,
                FirstName = res.User.FirstName,
                LastName = res.User.LastName,
                EmailId = res.User.EmailId,
                UserName = res.User.Username,
                Role = res.Role.Name
            };
        }

        public async Task<bool> UpdateAccount(UpdateModel model)
        {
            LoginModel loginModel = new LoginModel
            {
                UserName = model.Username,
                Password = model.Password,
            };

            var userview = await Login(loginModel);
            

            if (userview != null) { 
                User user = await _userRepository.GetUserByUsername(model.Username);
                user.Password = model.NewPassword;
                await _userRepository.Update(user);
                return true;
            }
            return false;
        }
    }
}
