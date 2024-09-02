using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project4.Application.DTO.Products;
using Project4.Application.Interfaces.Persistence.DataServices.Products;
using Project4.Application.Models;
using Project4.Domain.Entities;

namespace Project4.Application.Endpoints.APIs.Queries.Products
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, EndpointResult<PaginatedResult<Product>>>
    {
        private readonly IMapper _mapper;
        private readonly IProductsService _productService;
        public GetProductsQueryHandler(IMapper mapper, IProductsService productsService)
        {
            _mapper = mapper;
            _productService = productsService;
        }
        public async Task<EndpointResult<PaginatedResult<Product>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productService.GetProductsAsync(request.Search,
            request.Sort,
            request.Order,
            request.Page,
            request.Size);

            return new EndpointResult<PaginatedResult<Product>> (result);
        }
    }
}
