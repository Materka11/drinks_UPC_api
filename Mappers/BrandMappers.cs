using api.Dtos.Brand;
using api.Dtos.Producer;
using api.Models;

namespace api.Mappers
{
    public static class BrandMappers
    {
        public static BrandDto ToBrandDto(this Brand brandModel)
        {
            return new BrandDto
            {
                Id = brandModel.Id,
                Name = brandModel.Name,
                Producer = brandModel.Producer != null ? new ProducerDto
                {
                    Id = brandModel.Producer.Id,
                    Name = brandModel.Producer.Name,
                } : null
            };
        }

        public static Brand ToBrandFromCreateDto(this CreateBrandRequest brandDtoModel, Producer producerModel)
        {
            return new Brand
            {
                Name = brandDtoModel.Name,
                Producer = producerModel
            };
        }
    }
}

