namespace api.Models
{
    public class NutritionalValues
    {
        public int Id { get; set; }
        public string Calories { get; set; } = string.Empty;
        public string EnergyValue { get; set; } = string.Empty;
        public string Fat { get; set; } = string.Empty;
        public string SaturatedFat { get; set; } = string.Empty;
        public string Carbohydrates { get; set; } = string.Empty;
        public string Sugar { get; set; } = string.Empty;
        public string Protein { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public string Fiber { get; set; } = string.Empty;
        public string? Niacin { get; set; }
        public string? Biotin { get; set; }
        public string? Zinc { get; set; }
        public string? Selenium { get; set; }
        public string? VitaminC6 { get; set; }
        public string? VitaminC { get; set; }
        public string? VitaminB5 { get; set; }
        public string? VitaminB6 { get; set; }
        public string? VitaminB12 { get; set; }
        public string? VitaminE { get; set; }
    }
}