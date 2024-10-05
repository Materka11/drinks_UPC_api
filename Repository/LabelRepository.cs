using api.Data;
using api.Dtos.Label;
using api.Interfaces;
using api.Mappers;
using api.Models;
using api.Queries;
using Microsoft.EntityFrameworkCore;

namespace api.Respository
{
    public class LabelRepository : ILabelRepository
    {
        private readonly ApplicationDbContext _context;
        public LabelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LabelDto>> GetAllDtoAsync(LabelGetAllQuery query)
        {
            var labelsQuery = _context.Labels.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.LabelName))
            {
                labelsQuery = labelsQuery.Where(l => l.Name.Contains(query.LabelName));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("LabelName", StringComparison.OrdinalIgnoreCase))
                {
                    labelsQuery = query.isDecsending ? labelsQuery.OrderByDescending(l => l.Name) : labelsQuery.OrderBy(l => l.Name);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            var labels = await labelsQuery.Skip(skipNumber).Take(query.PageSize).ToListAsync();

            return labels.Select(l => l.ToLabelDto()).ToList();
        }

        public async Task<Label?> GetByIdAsync(int id)
        {
            return await _context.Labels.FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}