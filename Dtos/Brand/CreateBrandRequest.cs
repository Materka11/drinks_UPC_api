namespace api.Dtos.Brand
{
    public class CreateBrandRequest
    {
        public string Name { get; set; } = string.Empty;
        public CreateBrandRequest Producer { get; set; } = new CreateBrandRequest();
    }
}

