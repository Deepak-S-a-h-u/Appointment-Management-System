using Appointment_Management_System_Backend.Data;
using Appointment_Management_System_Backend.DtoModels;
using AppointmentManagementSystem.Models;
using Microsoft.AspNetCore.Http;
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
        private readonly ApplicationDbContext _context;
        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }
          [HttpPost]
        public IActionResult RegisterUser([FromBody] ApplicationUser applicationUser)
        {
            var user = await _userService.Authenticate(loginViewModel);
            if (user == null)
                return BadRequest(new { status = 0, message = "wrong UserName/Password" });
            return Ok(user);
        }

    }
}
