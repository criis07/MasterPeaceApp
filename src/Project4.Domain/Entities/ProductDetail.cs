using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Project4.Domain.Entities
{
    public class ProductDetail
    {
        [Key]
        public int ProductDetailId { get; set; }
        public int? Amount { get; set; }
        public decimal? UnitaryPrice { get; set; }
        public string? ProductImage { get; set; }
        public string? ProductModel { get; set; }
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        [JsonIgnore]
        public Product? Product { get; set; }
    }
}
