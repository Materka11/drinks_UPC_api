using api.Dtos.Category;

namespace api.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAllDtoAsync();
    }
}