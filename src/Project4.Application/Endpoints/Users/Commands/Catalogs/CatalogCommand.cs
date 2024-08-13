using System.ComponentModel.DataAnnotations;
using MediatR;
using Project4.Application.DTO.Catalogs;
using Project4.Application.DTO.Users;
using Project4.Application.Models;

namespace Project4.Application.Endpoints.Users.Commands.Catalogs
{
    public class CatalogCommand : IRequest<EndpointResult<CreateCatalogResponse>>
    {
        [Required]
        public string? ProductCode { get; set; }
        [Required]
        public string? CatalogDescription { get; set; }
    }
}
