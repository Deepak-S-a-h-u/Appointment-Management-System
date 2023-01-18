using Appointment_Management_System_Backend.Data;
using AppointmentManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ApplicationDbContext context,ILogger<DepartmentController> logger)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetDepartmentList()
        {
            var departmentList = _context.Departments.ToList();
            if (departmentList.Count != 0)
            {
                _logger.LogInformation("Data Displayed from Departments by return");
                return Ok(departmentList);
            }
            return Ok("no data found");
        }
        [HttpPost]
        public IActionResult PostDepartment([FromBody] Department department)
        {
            var status = 0;
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                status = 1;
                return Ok(status);
            }
            else
            {
                return Ok("Model state is not valid");
            }
        }
        [HttpPut]
        public IActionResult UpdateDepartment([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
                return Ok(department);
            }
            else
            {
                return Ok("Model state is not valid");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            if(id == 0)
            {
                return Ok("Can't delete null id");
            }
            else
            {
                var toDeleteDepartment=_context.Departments.Find(id);
                if(toDeleteDepartment!=null)
                { 
                _context.Departments.Remove(toDeleteDepartment);
                _context.SaveChanges();
                return Ok("data Deleted");
                }
                else
                {
                    return Ok("No department found on given id");
                }
            }
        }
    }
}
