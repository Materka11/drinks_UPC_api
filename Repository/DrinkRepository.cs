using api.Data;
using api.Dtos.Drink;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Respository
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly ApplicationDbContext _context;

        public DrinkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Drink> CreateAsync(Drink drinkModel)
        {
            await _context.Drinks.AddAsync(drinkModel);
            await _context.SaveChangesAsync();

            return drinkModel;
        }

        public async Task<Drink?> DeleteAsync(int id)
        {
            var drinkModel = await _context.Drinks
                        .Include(d => d.Brand)
                        .ThenInclude(b => b.Producer)
                        .Include(d => d.Category)
                        .Include(d => d.Label)
                        .Include(d => d.Barcode)
                        .FirstOrDefaultAsync(d => d.Id == id);

            if (drinkModel == null)
            {
                return null;
            }

            _context.Drinks.Remove(drinkModel);
            await _context.SaveChangesAsync();

            return drinkModel;
        }

        public async Task<List<DrinkDto>> GetAllDtoAsync()
        {
            return await _context.Drinks
                        .Include(d => d.Brand)
                        .ThenInclude(b => b.Producer)
                        .Include(d => d.Category)
                        .Include(d => d.Label)
                        .Include(d => d.Barcode)
                        .Include(d => d.NutritionalValues)
                        .Select(d => d.ToDrinkDto())
                        .ToListAsync();
        }

        public async Task<Drink?> GetByIdAsync(int id)
        {
            return await _context.Drinks
                        .Include(d => d.Brand)
                        .ThenInclude(b => b.Producer)
                        .Include(d => d.Category)
                        .Include(d => d.Label)
                        .Include(d => d.Barcode)
                        .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}