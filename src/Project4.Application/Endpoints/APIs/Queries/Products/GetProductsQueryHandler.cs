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

namespace Project4.Application.Endpoints.APIs.Queries.Products
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, EndpointResult<IEnumerable<GetProductsDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IProductsService _productService;
        public GetProductsQueryHandler(IMapper mapper, IProductsService productsService)
        {
            _mapper = mapper;
            _productService = productsService;
        }
        public async Task<EndpointResult<IEnumerable<GetProductsDTO>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productService.GetProductsAsync();

            var response = _mapper.Map<GetProductsDTO[]>(result);

            return new EndpointResult<IEnumerable<GetProductsDTO>>(response);
        }
    }
}
