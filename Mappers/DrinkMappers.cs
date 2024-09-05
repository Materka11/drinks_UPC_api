using api.Dtos.Brand;
using api.Dtos.Category;
using api.Dtos.Drink;
using api.Dtos.Label;
using api.Dtos.Producer;
using api.Models;

namespace api.Mappers
{
    public static class DrinkMappers
    {
        public static DrinkDto ToDrinkDto(this Drink drinkModel)
        {
            return new DrinkDto
            {
                Id = drinkModel.Id,
                Name = drinkModel.Name,
                Brand = drinkModel.Brand != null ? new BrandDto
                {
                    Id = drinkModel.Brand.Id,
                    Name = drinkModel.Brand.Name,
                    Producer = drinkModel.Brand.Producer != null ? new ProducerDto
                    {
                        Id = drinkModel.Brand.Producer.Id,
                        Name = drinkModel.Brand.Producer.Name,
                    } : null,
                } : null,
                Description = drinkModel.Description,
                Capacity = drinkModel.Capacity,
                Category = drinkModel.Category != null ? new CategoryDto
                {
                    Id = drinkModel.Category.Id,
                    Name = drinkModel.Category.Name,

                } : null,
                Storage = drinkModel.Storage,
                Barcode = drinkModel.Barcode,
                Composition = drinkModel.Composition,
                Label = drinkModel.Label != null ? new LabelDto
                {
                    Id = drinkModel.Label.Id,
                    Name = drinkModel.Label.Name,
                    Description = drinkModel.Label.Description,
                    ShortDescription = drinkModel.Label.ShortDescription,

                } : null,
                NutritionalValues = drinkModel.NutritionalValues,
                Preparation = drinkModel.Preparation,
            };
        }
    }
}


