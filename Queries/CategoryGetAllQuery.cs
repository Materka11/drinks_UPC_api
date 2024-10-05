namespace api.Queries
{
    public class CategoryGetAllQuery
    {
        public string? CategoryName { get; set; } = null;

        public string? SortBy { get; set; } = null;

        public bool IsDecsending { get; set; } = false;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}