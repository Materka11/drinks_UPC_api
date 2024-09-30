using api.Dtos.Category;
using api.Queries;

namespace api.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAllDtoAsync(CategoryGetAllQuery query);
    }
}