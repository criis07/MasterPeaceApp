using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project4.Application.DTO.Batchs;
using Project4.Application.Endpoints.Users.Commands.Batchs;
using Project4.Application.Models;

namespace Project4.Application.Interfaces.Persistence.DataServices.Batch
{
    public interface IBatchService
    {
        Task<CreateBatchResponse> CreateBatchAsync(CreateBatchCommand createBatch);
        Task<IEnumerable<Domain.Entities.Batch>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
