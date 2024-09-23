using api.Dtos.Drink;
using api.Models;

namespace api.Interfaces
{
    public interface IDrinkRepository
    {
        Task<List<DrinkDto>> GetAllDtoAsync();
        Task<Drink?> GetByIdAsync(int id);
        Task<Drink> CreateAsync(Drink drinkModel);
        Task<Drink?> DeleteAsync(int id);
    }
}