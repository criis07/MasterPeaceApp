using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project4.Api.Extensions;
using Project4.Application.DTO.Catalogs;
using Project4.Application.Endpoints.MarcasAutos.Queries;
using Project4.Application.Endpoints.Users.Commands.Catalogs;
using Project4.Application.Endpoints.Users.Queries;
using Project4.Application.Interfaces.Persistence.DataServices.Catalog;
using Project4.Infrastructure.Persistence;

namespace Project4.Api.Controllers
{
    public class CatalogsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CatalogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/api/v1/Catalog")]
        public async Task<ActionResult> CreateCatalogMethod([FromBody] CatalogCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }


        [HttpGet]
        [Route("/api/v1/Catalogs")]
        public async Task<ActionResult> GetAllCatalogs()
        {
            var request = new GetCatalogsQuery();
            var result = await _mediator.Send(request);
            return result.ToActionResult();
        }
    }
}
