using api.Data;
using api.Dtos.Drink;
using api.Interfaces;
using api.Mappers;
using api.Models;
using api.Queries;
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

        public async Task<List<DrinkDto>> GetAllDtoAsync(DrinkGetAllQuery query)
        {
            var drinksQuery = _context.Drinks
                        .Include(d => d.Brand)
                        .ThenInclude(b => b.Producer)
                        .Include(d => d.Category)
                        .Include(d => d.Label)
                        .Include(d => d.Barcode)
                        .Include(d => d.NutritionalValues)
                        .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.DrinkName))
            {
                drinksQuery = drinksQuery.Where(b => b.Name.Contains(query.DrinkName));
            }

            if (!string.IsNullOrWhiteSpace(query.BrandId))
            {
                int? brandId = string.IsNullOrEmpty(query.BrandId) ? (int?)null : int.Parse(query.BrandId);
                drinksQuery = drinksQuery.Where(b => b.BrandId == brandId);
            }

            if (!string.IsNullOrWhiteSpace(query.BrandName))
            {
                drinksQuery = drinksQuery.Where(b => b.Brand.Name.Contains(query.BrandName));
            }

            if (!string.IsNullOrWhiteSpace(query.ProducerId))
            {
                int? producerId = string.IsNullOrEmpty(query.ProducerId) ? (int?)null : int.Parse(query.ProducerId);
                drinksQuery = drinksQuery.Where(b => b.Brand.ProducerId == producerId);
            }

            if (!string.IsNullOrWhiteSpace(query.ProducerName))
            {
                drinksQuery = drinksQuery
                    .Where(b => b.Brand != null
                         && b.Brand.Producer != null
                         && b.Brand.Producer.Name != null
                         && b.Brand.Producer.Name.Contains(query.ProducerName));
            }

            if (!string.IsNullOrWhiteSpace(query.Capacity))
            {
                drinksQuery = drinksQuery.Where(b => b.Capacity.Contains(query.Capacity));
            }

            if (!string.IsNullOrWhiteSpace(query.CategoryId))
            {
                int? categoryId = string.IsNullOrEmpty(query.CategoryId) ? (int?)null : int.Parse(query.CategoryId);
                drinksQuery = drinksQuery.Where(b => b.CategoryId == categoryId);
            }

            if (!string.IsNullOrWhiteSpace(query.CategoryName))
            {
                drinksQuery = drinksQuery.Where(b => b.Category.Name.Contains(query.CategoryName));
            }

            if (!string.IsNullOrWhiteSpace(query.EAN))
            {
                drinksQuery = drinksQuery
                    .Where(b => b.Barcode != null
                         && b.Barcode.EAN.HasValue
                         && b.Barcode.EAN.Value.ToString().Contains(query.EAN.ToString()));
            }

            if (!string.IsNullOrWhiteSpace(query.LabelId))
            {
                int? labelId = string.IsNullOrEmpty(query.LabelId) ? (int?)null : int.Parse(query.LabelId);
                drinksQuery = drinksQuery.Where(b => b.LabelId == labelId);
            }

            if (!string.IsNullOrWhiteSpace(query.LabelName))
            {
                drinksQuery = drinksQuery.Where(b => b.Label != null && b.Label.Name.Contains(query.LabelName));
            }

            var drinks = await drinksQuery.ToListAsync();

            return drinks.Select(d => d.ToDrinkDto()).ToList();
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