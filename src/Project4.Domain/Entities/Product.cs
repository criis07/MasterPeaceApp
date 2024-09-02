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
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [MaxLength(10)]
        public int ProductCodeId { get; set; }
        public DateTime? ImportDate { get; set; }
        public int? BatchId { get; set; }
        public bool? Available { get; set; }

        [ForeignKey("BatchId")]
        public Batch? Batch { get; set; }
        [ForeignKey("ProductCodeId")]
        public Catalog? Catalog { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; } = null!;
        [JsonIgnore]
        public ICollection<Invoice> Invoices { get; set; } = null!;
    }
}
