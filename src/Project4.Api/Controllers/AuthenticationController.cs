using MediatR;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Project4.Application.Endpoints.MarcasAutos.Queries;
using Project4.Api.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Project4.Application.Endpoints.Users.Queries.Users;
using Microsoft.AspNetCore.Identity;
using Project4.Application.Endpoints.APIs.Commands.AuthUsers;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project4.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //Creamos nuestro punto de entrada para enviarlo a la clase handler por medio del mediator 
        [HttpPost]
        [Route("/Login")]
        public async Task<ActionResult> LoginAuthMethod([FromBody] LoginCommand command) 
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpPost]
        [Route("/register")]
        public async Task<ActionResult> RegisterAuthMethod([FromBody] RegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpGet]
        [Route("/api/user")]
        public async Task<ActionResult> GetUserInformationMethod()
        {
            var userId = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var request = new GetUserInfoQuery
            {
                Id = userId
            };
            var result = await _mediator.Send(request);
            return result.ToActionResult();
        }

        [HttpPost]
        [Authorize]
        [Route("/api/sign-in-with-token")]
        public async Task<ActionResult> SignInWithAccessToken([FromBody] AccessWithTokenCommand accessToken)
        {
            var result = await _mediator.Send(accessToken);
            return result.ToActionResult();
        }
    }
}
