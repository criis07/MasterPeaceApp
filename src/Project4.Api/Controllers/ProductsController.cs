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
        public async Task<ActionResult> GetProductsMethod()
        {
            var request = new GetProductsQuery();
            var result = await _mediator.Send(request);
            return result.ToActionResult();
        }
    }
}
