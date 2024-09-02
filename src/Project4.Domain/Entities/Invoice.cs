using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Domain.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? IssueDate { get; set; }
        public decimal? TotalDue { get; set; }
        public string? BillTo { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
