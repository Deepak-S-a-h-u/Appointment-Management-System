using Appointment_Management_System_Backend2.Data;
using Appointment_Management_System_Backend2.Models;
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
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AdminController(ILogger<AdminController> logger,UserManager<ApplicationUser> userManager,ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            
            var users = await _context.ApplicationUsers.Include(c=>c.Gender).ToListAsync();
            return Ok(users);
        }

    }
}
