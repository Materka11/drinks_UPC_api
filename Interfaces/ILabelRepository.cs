using api.Dtos.Label;
using api.Models;
using api.Queries;

namespace api.Interfaces
{
    public interface ILabelRepository
    {
        Task<List<LabelDto>> GetAllDtoAsync(LabelGetAllQuery query);
        Task<Label?> GetByIdAsync(int id);
    }
}