using api.Data;
using api.Dtos.Category;
using api.Interfaces;
using api.Mappers;
using api.Queries;
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

        public async Task<List<CategoryDto>> GetAllDtoAsync(CategoryGetAllQuery query)
        {
            var categoriesQuery = _context.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.CategoryName))
            {
                categoriesQuery = categoriesQuery.Where(b => b.Name.Contains(query.CategoryName));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("CategoryName", StringComparison.OrdinalIgnoreCase))
                {
                    categoriesQuery = query.IsDecsending ? categoriesQuery.OrderByDescending(c => c.Name) : categoriesQuery.OrderBy(c => c.Name);
                }
            }

            var categories = await categoriesQuery.ToListAsync();

            return categories.Select(c => c.toCategoryDto()).ToList();
        }
    }
}