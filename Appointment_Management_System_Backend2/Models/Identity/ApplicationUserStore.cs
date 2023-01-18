using Appointment_Management_System_Backend2.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend2.Models.Identity
{
    public class ApplicationUserStore : UserStore<ApplicationUser>

    {
        public ApplicationUserStore(ApplicationDbContext context) : base(context)
        {

        }
    }
}
