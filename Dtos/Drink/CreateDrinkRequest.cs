using api.Dtos.Barcode;
using api.Dtos.Brand;
using api.Dtos.NutritionalValues;

namespace api.Dtos.Drink
{
    public class CreateDrinkRequest
    {
        public string Name { get; set; } = string.Empty;
        public CreateBrandRequest Brand { get; set; } = new CreateBrandRequest();
        public string Description { get; set; } = string.Empty;
        public string Capacity { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string Storage { get; set; } = string.Empty;
        public CreateBarcodeRequest Barcode { get; set; } = new CreateBarcodeRequest();
        public string Composition { get; set; } = string.Empty;
        public int? LabelId { get; set; }
        public CreateNutritionalValuesRequest? NutritionalValues { get; set; } = new CreateNutritionalValuesRequest();
        public string Preparation { get; set; } = string.Empty;
    }
}