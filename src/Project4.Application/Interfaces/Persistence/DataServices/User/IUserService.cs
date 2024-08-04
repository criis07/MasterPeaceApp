using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Data;
using Project4.Application.DTO.Users;

namespace Project4.Application.Interfaces.Persistence.DataServices.User
{
    public  interface IUserService
    {
        Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO user);
        Task<LoginResponse> LoginUserAsync(LoginDTO loginData);
    }
}
