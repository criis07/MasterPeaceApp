using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project4.Application.DTO.Products;
using Project4.Domain.Entities;

namespace Project4.Application.Interfaces.Persistence.DataServices.Products
{
    public interface IProductsService
    {
        Task<PaginatedResult<Product>> GetProductsAsync(string? search, string? sort = "name", string? order = "asc", int page = 1, int size = 10);
    }
}
