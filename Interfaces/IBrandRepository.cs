using api.Dtos.Brand;
using api.Models;

namespace api.Interfaces
{
    public interface IBrandRepository
    {
        Task<List<BrandDto>> GetAllDtoAsync();
        Task<Brand?> GetByIdAsync(int id);
        Task<Brand> CreateAsync(Brand brandModel);
        Task<Brand?> DeleteAsync(int id);
    }
}