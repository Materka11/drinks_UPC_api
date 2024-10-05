namespace api.Queries
{
    public class LabelGetAllQuery
    {
        public string? LabelName { get; set; } = null;

        public string? SortBy { get; set; } = null;

        public bool isDecsending { get; set; } = false;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}