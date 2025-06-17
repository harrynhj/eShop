using Authentication.ApplicationCore.Models;
using Authentication.ApplicationCore.Services;
using Authentication.Infrastructure.Services;
using JwtAuthentcationManager;
using JwtAuthentcationManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [Route("api/Authentication")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly JwtTokenHandler _jwtTokenHandler;
        private readonly IAuthenticationService _authService;
        public AccountController(JwtTokenHandler jwtTokenHandler, IAuthenticationService authService) {
            this._jwtTokenHandler = jwtTokenHandler;
            this._authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var res = await _authService.Login(model);
            if (res != null) {
                var token = _jwtTokenHandler.GetToken(res.UserName, res.Role);
                return Ok(token);
            }
            else
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
        }

        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdmin(CustomerRegisterModel model)
        {
            var res = await _authService.AdminRegister(model);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest(new { message = "Registration failed" });
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser(UpdateModel model)
        {
            var res = await _authService.UpdateAccount(model);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest(new { message = "Update failed" });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var res = await _authService.DeleteAccount(id);
            if (res)
            {
                return Ok(new { message = "User deleted successfully" });
            }
            return NotFound(new { message = "User not found" });
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var res = await _authService.GetAllUsers();
            if (res != null && res.Count > 0)
            {
                return Ok(res);
            }
            return NotFound(new { message = "No users found" });
        }

        [HttpPost("customer-register")]
        public async Task<IActionResult> CustomerRegister(CustomerRegisterModel model)
        {
            var res = await _authService.CustomerRegister(model);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest(new { message = "Registration failed" });
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var res = await _authService.GetUserById(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound(new { message = "User not found" });
        }
    }
}