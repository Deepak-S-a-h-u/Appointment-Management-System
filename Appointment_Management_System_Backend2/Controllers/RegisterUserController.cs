using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend2.Controllers
{
    public class RegisterUserController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
      //  private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterUserController> _logger;

        public RegisterUserController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
        //    IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterUserController> logger
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
//            _emailSender = emailSender;
            _roleManager = roleManager;
        }
    }
}
