using Appointment_Management_System_Backend.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagementSystem.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int Id { get; set; }
        [Required]
       
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [NotMapped]
        public string Role { get; set; }
       

    }
}
