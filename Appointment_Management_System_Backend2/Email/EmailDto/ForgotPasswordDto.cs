using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend2.Email.EmailDto
{
    public class ForgotPasswordDto
    {
        [Required]
        public string Email { get; set; }
    }
}
