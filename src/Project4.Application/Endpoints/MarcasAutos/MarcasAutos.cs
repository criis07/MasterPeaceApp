using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project4.Domain.Common;

namespace Project4.Application.Endpoints.MarcasAutos
{
    public record MarcasAutos
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }
}
