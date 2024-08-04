using MediatR;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Project4.Application.Endpoints.MarcasAutos.Queries;
using Project4.Application.Endpoints.Users.Commands;
using Project4.Api.Extensions;

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
    }
}
