using AppointmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend.Models
{
    public class PatientDetails
    {
        public int Id { get; set; }
        public int PatientUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Disease { get; set; }
        public bool StatusPatient { get; set; }
    }
}
