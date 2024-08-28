using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project4.Application.Interfaces.Persistence.DataServices.Products;
using Project4.Domain.Entities;

namespace Project4.Infrastructure.Persistence.DataServices.ProductsService
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public ProductsService(ApplicationDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            /* var result = await _context.products.Include(p => p.ProductDetails)
            .Include(p => p.Invoices).ToListAsync();*/

            var result = await _context.products
                .Select(x => new Product
                {
                    ProductId = x.ProductId,
                    Available = x.Available,
                    ProductCodeId = x.ProductCodeId,
                    ImportDate = x.ImportDate,
                    BatchId = x.BatchId,
                    // Proyectar cada ProductDetail dentro de la lista de ProductDetails
                    ProductDetails = x.ProductDetails.Select(d => new ProductDetail
                    {
                        ProductDetailId = d.ProductDetailId,
                        Amount = d.Amount,
                        ProductId = d.ProductId,
                        ProductImage = d.ProductImage,
                        UnitaryPrice = d.UnitaryPrice,
                        ProductModel = d.ProductModel,
                    }).ToList(),
                    Invoices = x.Invoices.Select(d=> new Invoice
                    {
                        InvoiceId = d.InvoiceId,
                        ProductId=d.ProductId,
                        IssueDate = d.IssueDate,
                        TotalDue = d.TotalDue,
                        BillTo = d.BillTo
                    }).ToList()
                }).ToListAsync();
            return result;
        }

    }
}
