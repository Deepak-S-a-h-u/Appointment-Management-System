using Appointment_Management_System_Backend2.Utility.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend2.Utility.Repository
{
    public class ForgetPassword : IForgetPassword
    {
        public Task ForgetPasswordAsync()
        {
            if (string.IsNullOrEmpty(forgotPasswordDto.Email)) return BadRequest();
            var applicationUser = _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (applicationUser.Result == null) return NotFound();
            var code = await _userManager.GeneratePasswordResetTokenAsync(applicationUser.Result);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Content("http://localhost:3000/resetPassword/?" + "UserId=" + applicationUser.Result.Id + "&code=" + code);
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
                    applicationUser.Result.Name,//2
                    applicationUser.Result.UserName,//3
                    applicationUser.Result.Password,//4 
                    Message,
                    callbackUrl
                    );
            await _emailSender.SendEmailAsync(applicationUser.Result.Email, subject, messageBody);
        }
    }
}
