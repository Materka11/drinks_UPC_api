using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Producer
{
    public class UpdateProducerRequest
    {
        [Required(ErrorMessage = "Producer name is required.")]
        [StringLength(100, ErrorMessage = "Producer name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}

