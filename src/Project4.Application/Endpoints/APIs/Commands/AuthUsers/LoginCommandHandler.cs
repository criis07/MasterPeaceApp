using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project4.Application.DTO;
using Project4.Application.DTO.Users;
using Project4.Application.Endpoints.Users.Queries.Users;
using Project4.Application.Interfaces.Persistence.DataServices.User;
using Project4.Application.Models;
using Project4.Domain.Entities;

namespace Project4.Application.Endpoints.APIs.Commands.AuthUsers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, EndpointResult<LoginResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IMediator _mediator;

        public LoginCommandHandler(IMapper mapper, IUserService userService, IMediator mediator)
        {
            _mapper = mapper;
            _userService = userService;
            _mediator = mediator;
        }
        public async Task<EndpointResult<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var logRequest = _mapper.Map<LoginDTO>(request);
            var logMethod = await _userService.LoginUserAsync(logRequest);
            return new EndpointResult<LoginResponse>(logMethod);
        }
    }
}
