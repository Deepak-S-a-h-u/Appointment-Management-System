using Appointment_Management_System_Backend2.Email;
using Appointment_Management_System_Backend2.Models;
using Appointment_Management_System_Backend2.Models.Identity;
using Appointment_Management_System_Backend2.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private IWebHostEnvironment _env;
       /* private AppSettings _appSettings;*/
        public EmailController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager
           , RoleManager<ApplicationRole> roleManager, IEmailSender emailSender, IWebHostEnvironment env/*, IOptions<AppSettings> appSettings*/)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _signInManager = signInManager;
            _env = env;
/*            _appSettings = appSettings.Value;
*/        }
       


    }
}
