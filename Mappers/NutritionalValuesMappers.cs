using api.Dtos.NutritionalValues;
using api.Models;

namespace api.Mappers
{
    public static class NutritionalValuesMappers
    {
        public static NutritionalValues? ToNutritionalValuesFromCreateDto(this CreateNutritionalValuesRequest nutritionalValuesModel)
        {

            if (nutritionalValuesModel == null)
            {
                return null;
            }

            return new NutritionalValues
            {
                Calories = nutritionalValuesModel.Calories,
                EnergyValue = nutritionalValuesModel.EnergyValue,
                Fat = nutritionalValuesModel.Fat,
                SaturatedFat = nutritionalValuesModel.SaturatedFat,
                Carbohydrates = nutritionalValuesModel.Carbohydrates,
                Sugar = nutritionalValuesModel.Sugar,
                Protein = nutritionalValuesModel.Protein,
                Salt = nutritionalValuesModel.Salt,
                Fiber = nutritionalValuesModel.Fiber,
                Niacin = nutritionalValuesModel.Niacin,
                Biotin = nutritionalValuesModel.Biotin,
                Zinc = nutritionalValuesModel.Zinc,
                Selenium = nutritionalValuesModel.Selenium,
                VitaminC6 = nutritionalValuesModel.VitaminC6,
                VitaminC = nutritionalValuesModel.VitaminC,
                VitaminB5 = nutritionalValuesModel.VitaminB5,
                VitaminB6 = nutritionalValuesModel.VitaminB6,
                VitaminB12 = nutritionalValuesModel.VitaminB12,
                VitaminE = nutritionalValuesModel.VitaminE,
            };
        }
    }
}