using Appointment_Management_System_Backend2.Models;
using Appointment_Management_System_Backend2.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend2.Models
{
    public class ApplicationUser:IdentityUser
    {
       
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        
        [NotMapped]
        public string Role { get; set; }
        public List<ApplicationRole> ApplicationRoles { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
