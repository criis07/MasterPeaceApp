

namespace Project4.Application.Interfaces.Persistence.DataServices.Users.Queries
{
    public interface IMarcasAutosService
    {
        Task<IEnumerable<Domain.Entities.MarcasAutos>> GetAllMarcasAutos(CancellationToken cancellationToken = default);
    }
}
