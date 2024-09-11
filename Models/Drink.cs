namespace api.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? BrandId { get; set; }
        public Brand Brand { get; set; } = new Brand();
        public string Description { get; set; } = string.Empty;
        public string Capacity { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
        public string Storage { get; set; } = string.Empty;
        public Barcode Barcode { get; set; } = new Barcode();
        public string Composition { get; set; } = string.Empty;
        public int? LabelId { get; set; }
        public Label? Label { get; set; } = new Label();
        public NutritionalValues? NutritionalValues { get; set; }
        public string Preparation { get; set; } = string.Empty;
    }
}