namespace api.Queries
{
    public class DrinkGetAllQuery
    {
        public string? DrinkName { get; set; } = null;

        public string? BrandId { get; set; } = null;

        public string? BrandName { get; set; } = null;

        public string? ProducerId { get; set; } = null;

        public string? ProducerName { get; set; } = null;

        public string? Capacity { get; set; } = null;

        public string? CategoryId { get; set; } = null;

        public string? CategoryName { get; set; } = null;

        public string? EAN { get; set; } = null;

        public string? LabelId { get; set; } = null;

        public string? LabelName { get; set; } = null;

        public string? SortBy { get; set; } = null;

        public bool isDecsending { get; set; } = false;

    }
}