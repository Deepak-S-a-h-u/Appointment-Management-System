using Appointment_Management_System_Backend2.Models;
using Appointment_Management_System_Backend2.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Appointment_Management_System_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly  ILogger<DepartmentController> _logger;

        public DepartmentController(ApplicationDbContext context, ILogger<DepartmentController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetDepartmentList()
        {
            var departmentList = _context.Departments.ToList();
            if (departmentList.Count != 0)
            {
                return Ok(departmentList);
            }
            _logger.LogInformation("no data found in get department");
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
