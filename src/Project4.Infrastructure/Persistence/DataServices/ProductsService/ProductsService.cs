using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project4.Application.DTO.Products;
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
        public async Task<PaginatedResult<Product>> GetProductsAsync(string? search, string? sort = "name", string? order = "asc", int page = 1, int size = 10)
        {
            // Construir la consulta inicial
            var query = _context.products.AsQueryable();

            // Filtrar por búsqueda
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.ProductDetails.Any(d => d.ProductModel.ToLower().Contains(search.ToLower())));
            }

            // Ordenar los resultados
            query = sort switch
            {
                "sku" => order == "asc" ? query.OrderBy(x => x.ProductCodeId) : query.OrderByDescending(x => x.ProductCodeId),
                "name" => order == "asc" ? query.OrderBy(x => x.ProductDetails.FirstOrDefault().ProductModel) : query.OrderByDescending(x => x.ProductDetails.FirstOrDefault().ProductModel),
                "active" => order == "asc" ? query.OrderBy(x => x.Available) : query.OrderByDescending(x => x.Available),
                _ => order == "asc" ? query.OrderBy(x => x.ProductId) : query.OrderByDescending(x => x.ProductId)
            };

            // Obtener la longitud total antes de la paginación
            var totalItems = await query.CountAsync();

            // Aplicar paginación
            var products = await query
                .Skip((page) * size)
                .Take(size)
                .Select(x => new Product
                {
                    ProductId = x.ProductId,
                    Available = x.Available,
                    ProductCodeId = x.ProductCodeId,
                    ImportDate = x.ImportDate,
                    BatchId = x.BatchId,
                    ProductDetails = x.ProductDetails.Select(d => new ProductDetail
                    {
                        ProductDetailId = d.ProductDetailId,
                        Amount = d.Amount,
                        ProductId = d.ProductId,
                        ProductImage = d.ProductImage,
                        UnitaryPrice = d.UnitaryPrice,
                        ProductModel = d.ProductModel,
                    }).ToList()
                }).ToListAsync();

            // Calcular la última página
            var lastPage = (int)Math.Ceiling(totalItems / (double)size);

            // Preparar el resultado paginado
            var pagination = new Pagination
            {
                Length = totalItems,
                Size = size,
                Page = page,
                LastPage = lastPage,
                StartIndex = page * size,
                EndIndex = Math.Min((page + 1) * size, totalItems) -1
            }; 

            // Retornar los productos junto con la información de paginación
            return new PaginatedResult<Product>
            {
                Products = products,
                Pagination = pagination
            };
        }

    }
}
