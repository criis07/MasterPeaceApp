using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Project4.Application.DTO.Products;
using Project4.Application.Models;

namespace Project4.Application.Endpoints.APIs.Queries.Products
{
    public class GetProductsQuery : IRequest<EndpointResult<IEnumerable<GetProductsDTO>>>
    {

    }
}
