using Appointment_Management_System_Backend2.Models;
using Appointment_Management_System_Backend2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Management_System_Backend2.Utility.Repository.IRepository
{
    public interface IUserLogin
    {
        Task<ApplicationUser> Authenticate(LoginViewModel loginViewModel);

    }
}
