using Appointment_Management_System_Backend2.Data;
using Appointment_Management_System_Backend2.Models;
using Appointment_Management_System_Backend2.Models.Identity;
using Appointment_Management_System_Backend2.Models.ViewModel;
using Appointment_Management_System_Backend2.Utility;
using Appointment_Management_System_Backend2.Utility.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<RegisterUserController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private IWebHostEnvironment _env;
        private readonly IUserLogin _userLogin;

        public RegisterUserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            RoleManager<ApplicationRole> roleManager,
            ILogger<RegisterUserController> logger,
            ApplicationDbContext context,
            IWebHostEnvironment env,
            IUserLogin userLogin
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            _context = context;
            _emailSender = emailSender;
            _env = env;
            _userLogin = userLogin;
        }

        [NonAction]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                return BadRequest($"Error confirming email for user with ID '{userId}':");
            }
            return Ok();
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] ApplicationUser model)
        {
            if (!ModelState.IsValid) return BadRequest();
            var applicationUser = new ApplicationUser()
            {
               

                UserName = model.Email,
                Email = model.Email,
                Name = model.Name,
                Address = model.Address,
                GenderId = model.GenderId,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword
            };
            var result = await _userManager.CreateAsync(applicationUser, model.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Action(nameof(ConfirmEmail), "Account", new { userId = applicationUser.Id, code = code }, protocol: HttpContext.Request.Scheme);
                var pathToFile = _env.ContentRootPath + Path.DirectorySeparatorChar.ToString() + "Email"
                           + Path.DirectorySeparatorChar.ToString()
                           + "EmailTemplateHTML"
                           + Path.DirectorySeparatorChar.ToString()
                           + "EmailTemplateWelcome.html";
                string Message = "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>";
                var subject = "Confirm Account Registration";
                var builder = new BodyBuilder();
                using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
                {
                    builder.HtmlBody = SourceReader.ReadToEnd();
                }
                string messageBody = string.Format(builder.HtmlBody,
                    String.Format("{0:dddd, d MMMM yyyy}", DateTime.Now),
                        subject,
                        model.Email,
                        model.Name,
                        model.Password,
                        Message,
                        callbackUrl
                        );
                await _emailSender.SendEmailAsync(model.Email, subject, messageBody);
                return Ok();
            }
            else
            return BadRequest(result.Errors);
        }


        [HttpPost("LoginAuthorizeUser")]
        public async Task<IActionResult> LoginAuthorizeUser([FromBody] LoginViewModel loginViewModel)
        {
            var user = await _userLogin.Authenticate(loginViewModel);
            if (user == null)
                return BadRequest(new { status = 0, message = "wrong UserName/Password" });
            return Ok(user);
        }
    }
}



/*[HttpPost]
[Route("register")]
public async Task<IActionResult> RegisterUser([FromBody] ApplicationUser applicationUser)

{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    var user = new ApplicationUser
    {
        UserName = applicationUser.Email,
        Email = applicationUser.Email,
        Name = applicationUser.Name,
        Address = applicationUser.Address,
        GenderId = applicationUser.GenderId,
        Password = applicationUser.Password,
        ConfirmPassword = applicationUser.ConfirmPassword
    };
    var result = await _userManager.CreateAsync(user, applicationUser.Password);
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
        *//*await _roleManager.CreateAsync(role);
        await _context.SaveChangesAsync();*//*

        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var callbackUrl = Url.Page(
            "/Account/ConfirmEmail",
            pageHandler: null,
            values: new { area = "Identity", userId = user.Id, code = code },
            protocol: Request.Scheme);

        await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
            $"");

        if (_userManager.Options.SignIn.RequireConfirmedAccount)
        {
            return RedirectToPage("RegisterConfirmation", new { email = user.Email });
        }
        return Ok(user);
    }
    return BadRequest(result.Errors);
}*/