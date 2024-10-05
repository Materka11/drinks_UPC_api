namespace api.Queries
{
    public class BrandGetAllQuery
    {
        public string? BrandName { get; set; } = null;

        public string? ProducerId { get; set; } = null;

        public string? SortBy { get; set; } = null;

        public bool IsDecsending { get; set; } = false;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}