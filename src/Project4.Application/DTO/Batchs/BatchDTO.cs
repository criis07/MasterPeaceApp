using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Application.DTO.Batchs
{
    public class BatchDTO
    {
        public int BatchId { get; set; }
        public string? Origin { get; set; }
        public DateTime ImportDate { get; set; }
        public int GrossPrice { get; set; }
        public int ProfitMargin { get; set; }
        public int ImportCost { get; set; }
        public int TransportCost { get; set; }
    }
}
