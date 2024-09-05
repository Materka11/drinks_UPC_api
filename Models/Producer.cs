namespace api.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Brand>? Brands { get; } = new List<Brand>();
    }
}