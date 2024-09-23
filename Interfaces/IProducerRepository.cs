using api.Dtos.Producer;
using api.Models;

namespace api.Interfaces
{
    public interface IProducerRepository
    {
        Task<List<ProducerDto>> GetAllDtoAsync();
        Task<Producer?> GetByIdAsync(int id);
        Task<Producer> CreateAsync(Producer producerModel);
        Task<Producer?> UpdateAsync(int id, UpdateProducerRequest requestProducer);
        Task<Producer?> DeleteAsync(int id);
    }
}