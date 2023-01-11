using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagementSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
