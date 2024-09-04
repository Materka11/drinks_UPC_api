using System;
using api.Dtos.Producer;

namespace api.Dtos.Brand
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ProducerDto? Producer { get; set; } = new ProducerDto();
    }

}

