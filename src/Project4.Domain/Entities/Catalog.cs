using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Domain.Entities
{
    public  class Catalog
    {
        [Key]
        public int CatalogId { get; set; }
        [MaxLength(10)]
        public string? ProductCode { get; set; }
        public string? CatalogDescription { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
