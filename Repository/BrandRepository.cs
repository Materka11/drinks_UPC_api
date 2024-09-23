using api.Data;
using api.Dtos.Brand;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Respository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Brand> CreateAsync(Brand brandModel)
        {
            await _context.Brands.AddAsync(brandModel);
            await _context.SaveChangesAsync();
            return brandModel;
        }

        public async Task<Brand?> DeleteAsync(int id)
        {
            var brandModel = await _context.Brands
                        .Include(b => b.Producer)
                        .FirstOrDefaultAsync(b => b.Id == id);

            if (brandModel == null)
            {
                return null;
            }

            _context.Brands.Remove(brandModel);
            await _context.SaveChangesAsync();

            return brandModel;
        }

        public async Task<List<BrandDto>> GetAllDtoAsync()
        {
            return await _context.Brands
                        .Include(b => b.Producer)
                        .Select(b => b.ToBrandDto())
                        .ToListAsync();
        }

        public async Task<Brand?> GetByIdAsync(int id)
        {
            return await _context.Brands
                        .Include(b => b.Producer)
                        .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}