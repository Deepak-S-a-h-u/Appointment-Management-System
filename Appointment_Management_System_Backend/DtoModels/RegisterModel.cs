using Appointment_Management_System_Backend.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend.DtoModels
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int GenderId { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [NotMapped]
        public string Role { get; set; }

    }
}
