using api.Dtos.Barcode;
using api.Dtos.Brand;
using api.Dtos.Category;
using api.Dtos.Drink;
using api.Dtos.Label;
using api.Dtos.NutritionalValues;
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
                Brand = new BrandDto
                {
                    Id = drinkModel.Brand.Id,
                    Name = drinkModel.Brand.Name,
                    Producer = drinkModel.Brand.Producer != null ? new ProducerDto
                    {
                        Id = drinkModel.Brand.Producer.Id,
                        Name = drinkModel.Brand.Producer.Name,
                    } : null,
                },
                Description = drinkModel.Description,
                Capacity = drinkModel.Capacity,
                Category = new CategoryDto
                {
                    Id = drinkModel.Category.Id,
                    Name = drinkModel.Category.Name,

                },
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

        public static Drink ToDrinkFromCreateDto(this CreateDrinkRequest drinkDtoModel, Brand brandModel, Category categoryModel, Barcode barcodeModel, Label? labelModel, NutritionalValues? nutritionalValuesModel)
        {
            return new Drink
            {
                Name = drinkDtoModel.Name,
                Brand = brandModel,
                Description = drinkDtoModel.Description,
                Capacity = drinkDtoModel.Capacity,
                Category = categoryModel,
                Storage = drinkDtoModel.Storage,
                Barcode = barcodeModel,
                Composition = drinkDtoModel.Composition,
                Label = labelModel ?? null,
                NutritionalValues = nutritionalValuesModel ?? null,
                Preparation = drinkDtoModel.Preparation
            };
        }

        public static CreateDrinkRequest ToCreateDtoFromDrink(this Drink drinkModel, CreateBrandRequest brandDtoModel, CreateBarcodeRequest barcodeDtoModel, CreateNutritionalValuesRequest? nutritionalValuesModel)
        {
            return new CreateDrinkRequest
            {
                Name = drinkModel.Name,
                Brand = brandDtoModel,
                Description = drinkModel.Description,
                Capacity = drinkModel.Capacity,
                CategoryId = drinkModel.CategoryId,
                Storage = drinkModel.Storage,
                Barcode = barcodeDtoModel,
                Composition = drinkModel.Composition,
                LabelId = drinkModel.LabelId ?? null,
                NutritionalValues = nutritionalValuesModel ?? null,
                Preparation = drinkModel.Preparation
            };
        }
    }
}


