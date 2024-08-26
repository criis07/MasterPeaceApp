using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Project4.Application.DTO.Users;
using Project4.Application.Models;

namespace Project4.Application.Endpoints.APIs.Commands.AuthUsers
{
    public class LoginCommand : IRequest<EndpointResult<LoginResponse>>
    {

        [Required, EmailAddress]
        public string? Email { get; set; } = string.Empty;
        [Required]
        public string? Password { get; set; } = string.Empty;

    }
}
