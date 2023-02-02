using Appointment_Management_System_Backend2.Data;
using Appointment_Management_System_Backend2.Email;
using Appointment_Management_System_Backend2.Email.EmailDto;
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
        private readonly IEmailSender _emailSender;
        private IWebHostEnvironment _env;
        private readonly IUserLogin _userLogin;

        public RegisterUserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            RoleManager<ApplicationRole> roleManager,
            ILogger<RegisterUserController> logger,
            IWebHostEnvironment env,
            IUserLogin userLogin
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _env = env;
            _userLogin = userLogin;
        }

     /*   [NonAction]
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
        }*/

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
                ConfirmPassword = model.ConfirmPassword,
                Role = model.Role
                
            };
            var result = await _userManager.CreateAsync(applicationUser, model.Password);
            if (result.Succeeded)
            {
                var role = new ApplicationRole();

                if (applicationUser.Role == "")
                {
                   role.Name = Sd.Role_Patient;
                    //role.Name = Sd.Role_Admin;

                }
                else
                {
                    role.Name = applicationUser.Role;
                }
                await _userManager.AddToRoleAsync(applicationUser,role.Name);
                
/*                await _context.SaveChangesAsync(); 
*/

                         var code = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                

              //  var callbackUrl = Url.Content("https://localhost:44338/api/RegisterUser/ConfirmEmail/?" + "UserId=" + applicationUser.Id + "&code=" + code);
                
                var callbackUrl = Url.Content("http://localhost:3000/confirmEmail/?" + "UserId=" + applicationUser.Id + "&code=" + code);
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

        [HttpPost("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailDto confirmEmail)
         {
            var user = await _userManager.FindByIdAsync(confirmEmail.UserId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{confirmEmail.UserId}'.");
            }

            confirmEmail.Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(confirmEmail.Code));
            var result = await _userManager.ConfirmEmailAsync(user, confirmEmail.Code);
            if (!result.Succeeded)
            {
                return BadRequest($"Error Accurred While confirming email for user with ID : '{confirmEmail.UserId}':");
            }
            return Ok();
        }


        [HttpPost("ResendEmail")]
        public async Task<IActionResult> ResendEmail([FromBody] ResendEmailDto email)
        {
            if (string.IsNullOrEmpty(email.Email)) return BadRequest();
            var applicationUser =await _userManager.FindByEmailAsync(email.Email);
            if (applicationUser == null) return BadRequest($"User Not Registred With this Email: {email.Email}");
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Content("http://localhost:3000/confirmEmail/?" + "UserId=" + applicationUser.Id + "&code=" + code);
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
                    applicationUser.Email,
                    applicationUser.UserName,
                    applicationUser.Email,
                    Message,
                    callbackUrl
                    );
            await _emailSender.SendEmailAsync(applicationUser.Email, subject, messageBody);
            return Ok();
        }



    [HttpPost("ForgotPassword")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
    {
        if (string.IsNullOrEmpty(forgotPasswordDto.Email)) return BadRequest();
        var applicationUser = _userManager.FindByEmailAsync(forgotPasswordDto.Email);
        if (applicationUser.Result == null) return NotFound();
        var code = await _userManager.GeneratePasswordResetTokenAsync(applicationUser.Result);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Content("http://localhost:3000/resetPassword/?");
            var pathToFile = _env.ContentRootPath + Path.DirectorySeparatorChar.ToString() + "Email"
                          + Path.DirectorySeparatorChar.ToString()
                          + "EmailTemplateHTML"
                          + Path.DirectorySeparatorChar.ToString()
                          + "EmailTemplateForgetPassword.html";
            string Message = "Reset Your Password By Clicking Here<a href=\"" + callbackUrl + "\">here</a>";
        var subject = "Reset Your Password";
        var builder = new BodyBuilder();
        using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
        {
            builder.HtmlBody = SourceReader.ReadToEnd();
        }
        string messageBody = string.Format(builder.HtmlBody,
                String.Format("{0:dddd, d MMMM yyyy}", DateTime.Now),
                subject,
                applicationUser.Result.Email,
                applicationUser.Result.UserName,
                applicationUser.Result.Password,
                Message,
                callbackUrl
                );
        await _emailSender.SendEmailAsync(applicationUser.Result.Email, subject, messageBody);
        return Ok();
    }
    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPassWord(ResetPasswordDto resetPasswordDto)
    {
        if (resetPasswordDto == null && !ModelState.IsValid) return BadRequest();
        var user = _userManager.FindByIdAsync(resetPasswordDto.UserId);
        if (user.Result == null) return BadRequest();
        var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(resetPasswordDto.Token));
        var result = await _userManager.ResetPasswordAsync(user.Result, decodedToken, resetPasswordDto.Password);
        if (result.Succeeded) return Ok();
        return BadRequest("Something Went Wrong While Resetting your Password");
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