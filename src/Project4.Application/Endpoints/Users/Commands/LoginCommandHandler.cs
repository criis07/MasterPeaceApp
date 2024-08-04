using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project4.Application.DTO;
using Project4.Application.DTO.Users;
using Project4.Application.Interfaces.Persistence.DataServices.User;
using Project4.Application.Models;

namespace Project4.Application.Endpoints.Users.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, EndpointResult<LoginResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public LoginCommandHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<EndpointResult<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var logRequest = _mapper.Map<LoginDTO>(request);
            var logMethod = await _userService.LoginUserAsync(logRequest);

            return new EndpointResult<LoginResponse>(logMethod);
        }
    }
}
