using Appointment_Management_System_Backend2.Data;
using Appointment_Management_System_Backend2.Models;
using Appointment_Management_System_Backend2.Models.Identity;
using Appointment_Management_System_Backend2.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        //  private readonly IEmailSender _emailSender;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<RegisterUserController> _logger;
        private readonly ApplicationDbContext _context;

        public RegisterUserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
        //  IEmailSender emailSender,
            RoleManager<ApplicationRole> roleManager,
            ILogger<RegisterUserController> logger,
            ApplicationDbContext context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
           //_emailSender = emailSender;
            _roleManager = roleManager;
            _context = context;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] ApplicationUser applicationUser)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser { 
                UserName = applicationUser.Email, 
                Email = applicationUser.Email,
                Name=applicationUser.Name,
                Address=applicationUser.Address,
                GenderId=applicationUser.GenderId,
                Password=applicationUser.Password,
                ConfirmPassword=applicationUser.ConfirmPassword
            };
            var result = await _userManager.CreateAsync(user, applicationUser.Password) ;
            _logger.LogInformation("User created a new account with password.");
            if (result.Succeeded)
            {
                var role = new ApplicationRole();

                if (applicationUser.Role == "")
                {
                    role.Name = Sd.Role_Patient;
                }
                else
                {
                    role.Name = applicationUser.Role;
                }
                /*await _roleManager.CreateAsync(role);
                await _context.SaveChangesAsync();*/

                await  _userManager.AddToRoleAsync(user,role.Name);
                await _context.SaveChangesAsync();
                return Ok(user);
            }

            return BadRequest(result.Errors);
        }
    /*    This code assumes that you have already set up an ApplicationUser class and a UserManager<T> service in your project, and that you have defined a RegisterViewModel class with properties for the user's email, password, and role.

It also assumes you have already created the role and added it to your Identity framework.

This method receives a RegisterViewModel object as a parameter and first checks if the input is valid.If not, it returns a bad request.It then creates a new ApplicationUser object and uses the UserManager service to create a new user account with the email and password provided in the model.If the account is successfully created, it adds the role to the user using the UserManager service.Finally it returns an ok response or a BadRequest with error messages.

Please note that this is just an example and you should consider validations, error handling and security measures in your production code.*/





       /* public async Task<IActionResult> RegisterUser([FromBody] ApplicationUser applicationUser)
        {
            if(!ModelState.IsValid)
            {
                _logger.LogError("Invalid state");
                return Ok("ModelState Invalid");
            }
            else
            {
               if(applicationUser.Password != applicationUser.ConfirmPassword)
                {
                    _logger.LogWarning("Password not matched");
                    return Ok("Password Not Matched");
                }
                else
                {
                    _signInManager.SignInAsync(applicationUser.Role, Sd.Role_Admin);
                    _context.SaveChangesAsync();
                    return Ok(applicationUser);
                }
            }
        }
        */
    }
}
