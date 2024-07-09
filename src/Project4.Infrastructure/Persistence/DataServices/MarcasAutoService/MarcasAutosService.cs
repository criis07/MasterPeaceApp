using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project4.Application.Interfaces.Persistence.DataServices.Users.Queries;
using Microsoft.EntityFrameworkCore;
using Project4.Domain.Entities;


namespace Project4.Infrastructure.Persistence.DataServices.MarcasAutoService
{
    public class MarcasAutosService : IMarcasAutosService
    {
        private readonly ApplicationDbContext _marcasAutosDBContext;

        public MarcasAutosService(ApplicationDbContext applicationDbContext)
        {
            _marcasAutosDBContext = applicationDbContext;
        }
        public async Task<IEnumerable<Domain.Entities.MarcasAutos>> GetAllMarcasAutos(CancellationToken cancellationToken = default)
        {
           return await _marcasAutosDBContext.marcas_autos.ToListAsync(cancellationToken);
            
        }
    }
}
