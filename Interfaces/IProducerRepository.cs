using api.Dtos.Producer;
using api.Models;
using api.Queries;

namespace api.Interfaces
{
    public interface IProducerRepository
    {
        Task<List<ProducerDto>> GetAllDtoAsync(ProducerAllQuery query);
        Task<Producer?> GetByIdAsync(int id);
        Task<Producer> CreateAsync(Producer producerModel);
        Task<Producer?> UpdateAsync(int id, UpdateProducerRequest requestProducer);
        Task<Producer?> DeleteAsync(int id);
    }
}