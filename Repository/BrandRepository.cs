using api.Data;
using api.Dtos.Brand;
using api.Interfaces;
using api.Mappers;
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
        public Task<List<BrandDto>> GetAllDtoIncludeProducerAsync()
        {
            return _context.Brands
                        .Include(b => b.Producer)
                        .Select(b => b.ToBrandDto())
                        .ToListAsync();
        }
    }
}