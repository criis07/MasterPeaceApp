using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Project4.Application.DTO.Products;
using Project4.Application.Models;
using Project4.Domain.Entities;

namespace Project4.Application.Endpoints.APIs.Queries.Products
{
    public class GetProductsQuery : IRequest<EndpointResult<PaginatedResult<Product>>>
    {
        public string? Search { get; set; }
        public string? Sort { get; set; } = "name";
        public string? Order { get; set; } = "asc";
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
    }
}
