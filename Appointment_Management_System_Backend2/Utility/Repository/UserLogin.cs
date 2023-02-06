using Appointment_Management_System_Backend2.Data;
using Appointment_Management_System_Backend2.Models;
using Appointment_Management_System_Backend2.Models.Identity;
using Appointment_Management_System_Backend2.Models.ViewModel;
using Appointment_Management_System_Backend2.Utility.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend2.Utility.Repository
{
    public class UserLogin : IUserLogin
    {
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly ApplicationSignInManager _applicationSignInManager;
        private readonly AppSetting _appSettings;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _context;
        public UserLogin(ApplicationUserManager applicationUserManager, ApplicationSignInManager applicationSignInManager, IOptions<AppSetting> appSettings, RoleManager<ApplicationRole> roleManager,
            ApplicationDbContext context
)
        {
            _context = context;
            _applicationSignInManager = applicationSignInManager;
            _applicationUserManager = applicationUserManager;
            _appSettings = appSettings.Value;
            _roleManager = roleManager;

        }

        public async Task<ApplicationUser> Authenticate(LoginViewModel loginViewModel)
        {
            var result = await _applicationSignInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);

           

            if (result.Succeeded)
            {
                var applicationUser = await _applicationUserManager.FindByNameAsync(loginViewModel.UserName);
                applicationUser.PasswordHash = "";

                var roles = await _applicationUserManager.GetRolesAsync(applicationUser);

                //jwt token
                if (await _applicationUserManager.IsInRoleAsync(applicationUser, Roles.Role_Admin))
                {
                    applicationUser.Role = Roles.Role_Admin;
                    /*                    applicationUser.Role = SD.GetClaim && SD.PostClaim;
                    */
                }
                if (await _applicationUserManager.IsInRoleAsync(applicationUser, Roles.Role_Admin))
                    applicationUser.Role = Roles.Role_Admin;
                else if (await _applicationUserManager.IsInRoleAsync(applicationUser, Roles.Role_Doctor))
                    applicationUser.Role = Roles.Role_Doctor;
                else if (await _applicationUserManager.IsInRoleAsync(applicationUser, Roles.Role_Reception))
                    applicationUser.Role = Roles.Role_Reception;
                else if (await _applicationUserManager.IsInRoleAsync(applicationUser, Roles.Role_Patient))
                    applicationUser.Role = Roles.Role_Patient;

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = System.Text.Encoding.ASCII.GetBytes(_appSettings.Secret);

                var tokenDiscriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,applicationUser.Id),
                        new Claim(ClaimTypes.Email,applicationUser.Email),
                        new Claim(ClaimTypes.Role,applicationUser.Role)

                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    //    Expires = DateTime.UtcNow.AddSeconds(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDiscriptor);
                applicationUser.Token = tokenHandler.WriteToken(token);
                applicationUser.PasswordHash = "";

                return applicationUser;
            }
            else
            {
                return null;
            }
        }
    }
}
