using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Domain.Entities
{
    public class Batch
    {
        [Key]
        public int BatchId { get; set; }
        public string? Origin { get; set; }
        public DateTime? ImportDate { get; set; }
        public decimal? GrossPrice { get; set; }
        public decimal? ProfitMargin { get; set; }
        public decimal? ImportCost { get; set; }
        public decimal? TransportCost { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
