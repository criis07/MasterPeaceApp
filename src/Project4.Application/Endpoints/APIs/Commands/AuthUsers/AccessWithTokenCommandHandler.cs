using AutoMapper;
using MediatR;
using Project4.Application.DTO.Users;
using Project4.Application.Interfaces.Persistence.DataServices.User;
using Project4.Application.Models;

namespace Project4.Application.Endpoints.APIs.Commands.AuthUsers
{
    public class AccessWithTokenCommandHandler : IRequestHandler<AccessWithTokenCommand, EndpointResult<LoginResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public AccessWithTokenCommandHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService; 
        }
        public async Task<EndpointResult<LoginResponse>> Handle(AccessWithTokenCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.SignInWithTokenAsync(request.AccessToken);

            return new EndpointResult<LoginResponse>(result);
        }
    }
}
