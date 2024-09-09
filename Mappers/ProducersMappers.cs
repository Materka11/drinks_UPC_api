using api.Dtos.Producer;
using api.Models;

namespace api.Mappers
{
    public static class ProducersMappers
    {
        public static ProducerDto ToProducerDto(this Producer producerModel)
        {
            return new ProducerDto
            {
                Id = producerModel.Id,
                Name = producerModel.Name,
            };
        }

        public static Producer ToProducerFromCreateDto(this CreateProducerRequest producerDtoModel)
        {
            return new Producer
            {
                Name = producerDtoModel.Name,
            };
        }
    }
}
