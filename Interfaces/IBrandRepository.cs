using api.Dtos.Brand;
using api.Models;

namespace api.Interfaces
{
    public interface IBrandRepository
    {
        Task<List<BrandDto>> GetAllDtoIncludeProducerAsync();
        Task<Brand?> GetByIdIncludeProducerAsync(int id);
        Task<Brand> CreateAsync(Brand brandModel);
        Task<Brand?> DeleteAsync(int id);
    }
}