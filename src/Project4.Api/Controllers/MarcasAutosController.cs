using MediatR;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Project4.Api.Extensions;
using Project4.Application.Endpoints.MarcasAutos.Queries;

namespace Project4.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class MarcasAutosontroller : ControllerBase
    {
        private readonly IMediator _mediator;

        public MarcasAutosontroller(IMediator mediator)
        {
            _mediator = mediator;
        }
        //Creamos nuestro punto de entrada para enviarlo a la clase handler por medio del mediator 
        [HttpGet]
        [Route("/marcas")]
        public async Task<ActionResult> GetMarcasAutosAsync()
        {
            var request = new MarcasAutosQuery(); 
            var result = await _mediator.Send(request);
            return result.ToActionResult();
        }
    }

}
