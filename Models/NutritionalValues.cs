using System;

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
        public string Sodium { get; set; } = string.Empty;
        public string Fiber { get; set; } = string.Empty;
    }
}