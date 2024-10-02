namespace api.Queries
{
    public class ProducerAllQuery
    {
        public string? ProducerName { get; set; } = null;

        public string? SortBy { get; set; } = null;

        public bool isDecsending { get; set; } = false;
    }
}