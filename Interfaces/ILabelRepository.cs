using api.Dtos.Label;
using api.Models;

namespace api.Interfaces
{
    public interface ILabelRepository
    {
        Task<List<LabelDto>> GetAllDtoAsync();
        Task<Label?> GetByIdAsync(int id);
    }
}