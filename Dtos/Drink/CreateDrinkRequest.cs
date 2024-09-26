using api.Dtos.Barcode;
using api.Dtos.Brand;
using api.Dtos.NutritionalValues;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Drink
{
    public class CreateDrinkRequest
    {
        [Required(ErrorMessage = "Drink name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Drink name must be between 2 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Brand information is required.")]
        public CreateBrandRequest Brand { get; set; } = new CreateBrandRequest();

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Capacity is required.")]
        [RegularExpression(@"^\d+(\.\d{1,2})? (l)$", ErrorMessage = "Capacity must be a valid format (e.g., '1.5 L').")]
        public string Capacity { get; set; } = string.Empty;

        [Required(ErrorMessage = "CategoryId is required.")]
        public int CategoryId { get; set; }

        [StringLength(200, ErrorMessage = "Storage information cannot exceed 200 characters.")]
        public string Storage { get; set; } = string.Empty;

        [Required(ErrorMessage = "Barcode information is required.")]
        public CreateBarcodeRequest Barcode { get; set; } = new CreateBarcodeRequest();

        [StringLength(1000, ErrorMessage = "Composition cannot exceed 1000 characters.")]
        public string Composition { get; set; } = string.Empty;

        public int? LabelId { get; set; }

        public CreateNutritionalValuesRequest? NutritionalValues { get; set; } = new CreateNutritionalValuesRequest();

        [StringLength(500, ErrorMessage = "Preparation instructions cannot exceed 500 characters.")]
        public string Preparation { get; set; } = string.Empty;
    }
}