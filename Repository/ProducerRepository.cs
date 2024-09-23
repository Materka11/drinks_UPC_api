using api.Data;
using api.Dtos.Producer;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Respository
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly ApplicationDbContext _context;

        public ProducerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Producer> CreateAsync(Producer producerModel)
        {
            await _context.Producers.AddAsync(producerModel);
            await _context.SaveChangesAsync();

            return producerModel;
        }

        public async Task<Producer?> DeleteAsync(int id)
        {
            var producerModel = await _context.Producers.FirstOrDefaultAsync(p => p.Id == id);

            if (producerModel == null)
            {
                return null;
            }

            _context.Producers.Remove(producerModel);
            await _context.SaveChangesAsync();

            return producerModel;
        }

        public async Task<List<ProducerDto>> GetAllDtoAsync()
        {
            return await _context.Producers.Select(p => p.ToProducerDto()).ToListAsync();
        }

        public async Task<Producer?> GetByIdAsync(int id)
        {
            return await _context.Producers.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Producer?> UpdateAsync(int id, UpdateProducerRequest requestProducer)
        {
            var exisitingProducer = await _context.Producers.FirstOrDefaultAsync(p => p.Id == id);

            if (exisitingProducer == null)
            {
                return null;
            }

            _context.Entry(exisitingProducer).CurrentValues.SetValues(requestProducer);
            await _context.SaveChangesAsync();

            return exisitingProducer;
        }
    }
}