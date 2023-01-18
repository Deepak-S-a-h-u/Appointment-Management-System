using Appointment_Management_System_Backend2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend2.Models
{
    public class DoctorDetails
    {
        public int Id { get; set; }
        public int DoctorUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        

    }
}
