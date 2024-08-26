using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Project4.Application.DTO.Catalogs;
using Project4.Application.Models;
using Project4.Domain.Entities;

namespace Project4.Application.Endpoints.Users.Commands.Catalogs
{
    public class UpdateCatalogCommand : IRequest<EndpointResult<UpdateCatalogResponse>>
    {
        public int CatalogId { get; set; }
        public string? ProductCode { get; set; }
        public string? CatalogDescription { get; set; }
    }
}
