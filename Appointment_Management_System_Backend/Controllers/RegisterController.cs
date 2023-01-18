using Appointment_Management_System_Backend.Data;
using Appointment_Management_System_Backend.DtoModels;
using Appointment_Management_System_Backend.Utility;
using AppointmentManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        public RegisterController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] ApplicationUser applicationUser)
        {
            //applicationUser.UserName= applicationUser.Email;

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Name = applicationUser.Name,
                    UserName = applicationUser.Email,
                    Email = applicationUser.Email,
                    //  PhoneNumber = applicationUser.PhoneNumber,
                    GenderId = applicationUser.GenderId,
                    Address = applicationUser.Address,
                    ConfirmPassword = applicationUser.ConfirmPassword,
                    Password = applicationUser.Password,
                    Role = applicationUser.Role
                };
                //var user = new IdentityUser { UserName = applicationUser.Email, Email = applicationUser.Email };
                var result = await _userManager.CreateAsync(user, applicationUser.Password);
                if (result.Succeeded)
                {
                    //   _logger.LogInformation("User created a new account with password.");

                    if (!await _roleManager.RoleExistsAsync(Sd.Role_Admin))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Sd.Role_Admin));
                    }
                    if (!await _roleManager.RoleExistsAsync(Sd.Role_Patient))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Sd.Role_Patient));
                    }
                    if (!await _roleManager.RoleExistsAsync(Sd.Role_Reception))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Sd.Role_Reception));
                    }
                    if (!await _roleManager.RoleExistsAsync(Sd.Role_Doctor))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Sd.Role_Doctor));
                    }

                    await _userManager.AddToRoleAsync(user, Sd.Role_Admin);


                    _context.ApplicationUsers.AddAsync(user);
                    _context.SaveChangesAsync();


                }
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
           
        }
    }
}
