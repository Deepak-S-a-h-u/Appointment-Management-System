using Appointment_Management_System_Backend2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend2.UsersDto
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string PatientUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string Disease { get; set; }
        public bool StatusPatient { get; set; }

    }
}
