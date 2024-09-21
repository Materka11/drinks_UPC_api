using api.Data;
using api.Dtos.Category;
using api.Interfaces;
using api.Mappers;
using Microsoft.EntityFrameworkCore;

namespace api.Respository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public Task<List<CategoryDto>> GetAllDtoAsync()
        {
            return _context.Categories.Select(c => c.toCategoryDto()).ToListAsync();
        }
    }
}