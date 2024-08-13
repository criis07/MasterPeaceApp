using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Project4.Application.DTO.Catalogs
{
    public class CreateCatalogDTO
    {
        public string? ProductCode { get; set; }
        public string? CatalogDescription { get; set; }
    }
}
