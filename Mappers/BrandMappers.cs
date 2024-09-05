using api.Dtos.Brand;
using api.Dtos.Producer;
using api.Models;

namespace api.Mappers
{
    public static class BrandMappers
    {
        public static BrandDto ToBrandDto(this Brand brandmodel)
        {
            return new BrandDto
            {
                Id = brandmodel.Id,
                Name = brandmodel.Name,
                Producer = brandmodel.Producer != null ? new ProducerDto
                {
                    Id = brandmodel.Producer.Id,
                    Name = brandmodel.Producer.Name,
                } : null
            };
        }
    }
}

