using api.Dtos.Brand;
using api.Models;
using api.Queries;

namespace api.Interfaces
{
    public interface IBrandRepository
    {
        Task<List<BrandDto>> GetAllDtoAsync(BrandGetAllQuery query);
        Task<Brand?> GetByIdAsync(int id);
        Task<Brand> CreateAsync(Brand brandModel);
        Task<Brand?> DeleteAsync(int id);
    }
}