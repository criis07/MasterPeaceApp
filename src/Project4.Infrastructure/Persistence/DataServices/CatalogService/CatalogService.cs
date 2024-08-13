using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project4.Application.DTO.Catalogs;
using Project4.Application.DTO.Users;
using Project4.Application.Interfaces.Persistence;
using Project4.Application.Interfaces.Persistence.DataServices.Catalog;
using Project4.Domain.Entities;

namespace Project4.Infrastructure.Persistence.DataServices.CatalogService
{
    public class CatalogService : ICatalogService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public CatalogService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<CreateCatalogResponse> CreateCatalogAsync(CreateCatalogDTO catalogDTO)
        {
            var catalog = _context.catalogs.Add(new Catalog
            {
                ProductCode = catalogDTO.ProductCode,
                CatalogDescription = catalogDTO.CatalogDescription
            });
            await _context.SaveChangesAsync();
            return new CreateCatalogResponse { Success = true, Message = "Catalog successfully added " };
        }

        public async Task<IEnumerable<Catalog>> GetAllCatalogsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.catalogs.ToListAsync(cancellationToken);
        }
    }
}
