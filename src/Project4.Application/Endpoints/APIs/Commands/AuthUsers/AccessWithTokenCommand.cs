using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Project4.Application.DTO.Users;
using Project4.Application.Models;

namespace Project4.Application.Endpoints.APIs.Commands.AuthUsers
{
    public class AccessWithTokenCommand : IRequest<EndpointResult<LoginResponse>>
    {
        public string? AccessToken { get; set; }
    }
}
