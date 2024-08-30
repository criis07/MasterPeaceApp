using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Application.DTO.Products
{
    public class Pagination
    {
        public int Length { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
        public int LastPage { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
    }

    public class PaginatedResult<T>
    {
        public IEnumerable<T>? Products { get; set; }
        public Pagination? Pagination { get; set; }
    }

}
