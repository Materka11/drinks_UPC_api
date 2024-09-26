using System.ComponentModel.DataAnnotations;

namespace api.Dtos.NutritionalValues
{
    public class CreateNutritionalValuesRequest
    {
        [Required(ErrorMessage = "Calories are required.")]
        [RegularExpression(@"^\d+(\.\d{1,2})? kcal$", ErrorMessage = "Calories must be a valid number followed by 'kcal'.")]
        public string Calories { get; set; } = string.Empty;

        [Required(ErrorMessage = "Energy value is required.")]
        [RegularExpression(@"^\d+(\.\d{1,2})? KJ$", ErrorMessage = "Energy value must be a valid number followed by 'KJ'.")]
        public string EnergyValue { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fat is required.")]
        [RegularExpression(@"^\d+(\.\d{1,2})? g$", ErrorMessage = "Fat must be a valid number followed by 'g'.")]
        public string Fat { get; set; } = string.Empty;

        [Required(ErrorMessage = "Saturated fat is required.")]
        [RegularExpression(@"^\d+(\.\d{1,2})? g$", ErrorMessage = "Saturated fat must be a valid number followed by 'g'.")]
        public string SaturatedFat { get; set; } = string.Empty;

        [Required(ErrorMessage = "Carbohydrates are required.")]
        [RegularExpression(@"^\d+(\.\d{1,2})? g$", ErrorMessage = "Carbohydrates must be a valid number followed by 'g'.")]
        public string Carbohydrates { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sugar is required.")]
        [RegularExpression(@"^\d+(\.\d{1,2})? g$", ErrorMessage = "Sugar must be a valid number followed by 'g'.")]
        public string Sugar { get; set; } = string.Empty;

        [Required(ErrorMessage = "Protein is required.")]
        [RegularExpression(@"^\d+(\.\d{1,2})? g$", ErrorMessage = "Protein must be a valid number followed by 'g'.")]
        public string Protein { get; set; } = string.Empty;

        [Required(ErrorMessage = "Salt is required.")]
        [RegularExpression(@"^\d+(\.\d{1,2})? g$", ErrorMessage = "Salt must be a valid number followed by 'g'.")]
        public string Salt { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fiber is required.")]
        [RegularExpression(@"^\d+(\.\d{1,2})? g$", ErrorMessage = "Fiber must be a valid number followed by 'g'.")]
        public string Fiber { get; set; } = string.Empty;

        [RegularExpression(@"^\d+(\.\d{1,2})? mg$", ErrorMessage = "Niacin must be a valid number followed by 'mg'.")]
        public string? Niacin { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})? g$", ErrorMessage = "Biotin must be a valid number followed by 'g'.")]
        public string? Biotin { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})? g$", ErrorMessage = "Zinc must be a valid number followed by 'g'.")]
        public string? Zinc { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})? g$", ErrorMessage = "Selenium must be a valid number followed by 'g'.")]
        public string? Selenium { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})? g$", ErrorMessage = "Vitamin C6 must be a valid number followed by 'g'.")]
        public string? VitaminC6 { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})? mg$", ErrorMessage = "Vitamin C must be a valid number followed by 'mg'.")]
        public string? VitaminC { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})? mg$", ErrorMessage = "Vitamin B5 must be a valid number followed by 'mg'.")]
        public string? VitaminB5 { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})? mg$", ErrorMessage = "Vitamin B6 must be a valid number followed by 'mg'.")]
        public string? VitaminB6 { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})? µg$", ErrorMessage = "Vitamin B12 must be a valid number followed by 'µg'.")]
        public string? VitaminB12 { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})? mg$", ErrorMessage = "Vitamin E must be a valid number followed by 'mg'.")]
        public string? VitaminE { get; set; }
    }
}