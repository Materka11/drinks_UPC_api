using api.Data;
using api.Dtos.Brand;
using api.Interfaces;
using api.Mappers;
using api.Models;
using api.Queries;
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

        public async Task<List<BrandDto>> GetAllDtoAsync(BrandGetAllQuery query)
        {
            var brandsQuery = _context.Brands
                        .Include(b => b.Producer)
                        .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.BrandName))
            {
                brandsQuery = brandsQuery.Where(b => b.Name.Contains(query.BrandName));
            }

            if (!string.IsNullOrWhiteSpace(query.ProducerId))
            {

                brandsQuery = brandsQuery.Where(b => b.Producer != null && b.Producer.Id.ToString() == query.ProducerId);
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("BrandName", StringComparison.OrdinalIgnoreCase))
                {
                    brandsQuery = query.IsDecsending ? brandsQuery.OrderByDescending(b => b.Name) : brandsQuery.OrderBy(b => b.Name);
                }

                if (query.SortBy.Equals("ProducerId", StringComparison.OrdinalIgnoreCase))
                {
                    brandsQuery = query.IsDecsending ? brandsQuery.OrderByDescending(b => b.ProducerId) : brandsQuery.OrderBy(b => b.ProducerId);
                }
            }

            var brands = await brandsQuery.ToListAsync();

            return brands.Select(b => b.ToBrandDto()).ToList();
        }

        public async Task<Brand?> GetByIdAsync(int id)
        {
            return await _context.Brands
                        .Include(b => b.Producer)
                        .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}