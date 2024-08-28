using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project4.Domain.Entities;

namespace Project4.Application.Interfaces.Persistence.DataServices.Products
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
