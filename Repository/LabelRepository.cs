using api.Data;
using api.Dtos.Label;
using api.Interfaces;
using api.Mappers;
using api.Models;
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

        public async Task<List<LabelDto>> GetAllDtoAsync()
        {
            return await _context.Labels.Select(l => l.ToLabelDto()).ToListAsync();
        }

        public async Task<Label?> GetByIdAsync(int id)
        {
            return await _context.Labels.FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}