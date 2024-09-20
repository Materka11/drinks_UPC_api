using api.Dtos.Brand;

namespace api.Interfaces
{
    public interface IBrandRepository
    {
        Task<List<BrandDto>> GetAllDtoIncludeProducerAsync();
    }
}