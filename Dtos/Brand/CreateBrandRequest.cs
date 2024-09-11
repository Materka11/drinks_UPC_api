using api.Dtos.Producer;

namespace api.Dtos.Brand
{
    public class CreateBrandRequest
    {
        public string Name { get; set; } = string.Empty;
        public CreateProducerRequest Producer { get; set; } = new CreateProducerRequest();
    }
}

