using System;
using api.Models;
using api.Dtos.Brand;
using api.Dtos.Category;
using api.Dtos.Label;

namespace api.Dtos.Drink
{
    public class DrinkDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public BrandDto? Brand { get; set; } = new BrandDto();
        public string Description { get; set; } = string.Empty;
        public string Capacity { get; set; } = string.Empty;
        public CategoryDto? Category { get; set; } = new CategoryDto();
        public string Storage { get; set; } = string.Empty;
        public Barcode Barcode { get; set; } = new Barcode();
        public string Composition { get; set; } = string.Empty;
        public LabelDto? Label { get; set; }
        public NutritionalValues? NutritionalValues { get; set; }
        public string Preparation { get; set; } = string.Empty;
    }

}

