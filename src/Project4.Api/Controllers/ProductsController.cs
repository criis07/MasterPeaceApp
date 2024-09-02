using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project4.Api.Extensions;
using Project4.Application.Endpoints.APIs.Queries.Products;

namespace Project4.Api.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/api/v1/products")]
        public async Task<ActionResult> GetProductsMethod([FromQuery] string? search, [FromQuery] string? sort = "name", [FromQuery] string? order = "asc", [FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            var request = new GetProductsQuery
            {
                Search = search,
                Sort = sort,
                Order = order,
                Page = page,
                Size = size
            };
            var result = await _mediator.Send(request);
            return result.ToActionResult();
        }
    }
}
