using AppointmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend.Models
{
    public class AppointmentDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public PatientDetails PatientDetails { get; set; }
        public DateTime Time { get; set; }
        public int DoctorId { get; set; }
        public DoctorDetails DoctorDetails { get; set; }
        public bool IsFixed { get; set; }
    }
}
