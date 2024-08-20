using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Project4.Application.DTO.Catalogs;
using Project4.Application.Models;

namespace Project4.Application.Endpoints.Users.Commands.Catalogs
{
    public class DeleteCatalogCommand : IRequest<EndpointResult<DeleteCatalogResponse>>
    {
        public int CatalogId { get; set; }
    }
}
