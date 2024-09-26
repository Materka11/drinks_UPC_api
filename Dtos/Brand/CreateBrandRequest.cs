using api.Dtos.Producer;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Brand
{
    public class CreateBrandRequest
    {
        [Required(ErrorMessage = "Brand name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Brand name must be between 2 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Producer information is required.")]
        public CreateProducerRequest Producer { get; set; } = new CreateProducerRequest();
    }
}

