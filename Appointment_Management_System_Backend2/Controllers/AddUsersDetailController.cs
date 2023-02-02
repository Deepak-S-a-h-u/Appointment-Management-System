using Appointment_Management_System_Backend2.Data;
using Appointment_Management_System_Backend2.Models;
using Appointment_Management_System_Backend2.UsersDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddUsersDetailController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<AddUsersDetailController> _logger;
        public AddUsersDetailController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<AddUsersDetailController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost/*("{patientDto}")*/]
        public async Task<IActionResult> AddPatientDetails([FromBody] PatientDetails patientDetails)
        {
            //  var user = await _userManager.FindByIdAsync(patientDto.PatientUserId);
             await _context.PatientDetails.AddAsync(patientDetails);
            _context.SaveChangesAsync();
            return Ok();
        }
    }
}
