using api.Dtos.Label;
using api.Models;

namespace api.Mappers
{
    public static class LabelsMappers
    {
        public static LabelDto ToLabelDto(this Label labelModel)
        {
            return new LabelDto
            {
                Id = labelModel.Id,
                Name = labelModel.Name,
                Description = labelModel.Description,
                ShortDescription = labelModel.ShortDescription,
            };
        }
    }
}

