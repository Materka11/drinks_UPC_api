using api.Dtos.Drink;
using api.Models;
using api.Queries;

namespace api.Interfaces
{
    public interface IDrinkRepository
    {
        Task<List<DrinkDto>> GetAllDtoAsync(DrinkGetAllQuery query);
        Task<Drink?> GetByIdAsync(int id);
        Task<Drink> CreateAsync(Drink drinkModel);
        Task<Drink?> DeleteAsync(int id);
    }
}