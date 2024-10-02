namespace api.Queries
{
    public class CategoryGetAllQuery
    {
        public string? CategoryName { get; set; } = null;

        public string? SortBy { get; set; } = null;

        public bool IsDecsending { get; set; } = false;
    }
}