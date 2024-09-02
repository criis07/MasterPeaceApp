using System.Dynamic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project4.Api.Extensions;
using Project4.Application.Endpoints.Users.Commands.Batchs;
using Project4.Application.Endpoints.Users.Queries.Batchs;
using Project4.Application.Models;

namespace Project4.Api.Controllers
{
    public class BatchController : Controller
    {
        private readonly IMediator _mediator;
        public BatchController(IMediator mediator)
        {
            _mediator = mediator;            
        }

        [HttpGet]
        [Route("/api/v1/batch")]
        public async Task<ActionResult> GetAllBatchs()
        {
            var request = new GetBatchsQuery();
            var result = await _mediator.Send(request);
            return result.ToActionResult();
        }

        [HttpPost]
        [Route("/api/v1/batch")]
        public async Task<ActionResult> CreateBatch([FromBody] CreateBatchCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

    }
}
