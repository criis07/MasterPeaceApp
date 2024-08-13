using Project4.Application.DTO.Catalogs;


namespace Project4.Application.Interfaces.Persistence.DataServices.Catalog
{
    public interface ICatalogService
    {
        Task<CreateCatalogResponse> CreateCatalogAsync(CreateCatalogDTO catalogDTO);
        Task<IEnumerable<Domain.Entities.Catalog>> GetAllCatalogsAsync(CancellationToken cancellationToken = default);
    }
}
