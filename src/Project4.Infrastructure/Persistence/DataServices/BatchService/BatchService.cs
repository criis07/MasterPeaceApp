using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project4.Application.DTO.Batchs;
using Project4.Application.DTO.Catalogs;
using Project4.Application.Endpoints.Users.Commands.Batchs;
using Project4.Application.Interfaces.Persistence.DataServices.Batch;
using Project4.Application.Models;
using Project4.Domain.Entities;

namespace Project4.Infrastructure.Persistence.DataServices.BatchService
{
    public class BatchService : IBatchService
    {
        private readonly ApplicationDbContext _context;
        public BatchService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CreateBatchResponse> CreateBatchAsync(CreateBatchCommand createBatch)
        {
            var batch = _context.batch.Add(new Batch
            {
                Origin = createBatch.Origin,
                ImportCost = createBatch.ImportCost,
                GrossPrice = createBatch.GrossPrice,
                ProfitMargin = createBatch.ProfitMargin,
                TransportCost = createBatch.TransportCost,
                ImportDate = createBatch.ImportDate,
            });
            await _context.SaveChangesAsync();
            return new CreateBatchResponse { Success = true, Message = "Batch successfully added " };
        }

        public async Task<IEnumerable<Batch>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.batch.ToListAsync(cancellationToken);       
        }
    }
}
