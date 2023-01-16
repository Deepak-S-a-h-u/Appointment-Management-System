using AppointmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend.Models
{
    public class Reception
    {
        public int Id { get; set; }
        public int ReceptionUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    
    }
}
