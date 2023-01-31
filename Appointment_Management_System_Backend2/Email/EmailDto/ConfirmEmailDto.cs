using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend2.Email
{
    public class ConfirmEmailDto
    {
            public string UserId { get; set; }
            public string Code { get; set; }
    }
}
