using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Application.DTO.Catalogs
{
    public class UpdateCatalogDTO : CreateCatalogDTO
    {
        public string? CatalogId {  get; set; } 
    }
}
