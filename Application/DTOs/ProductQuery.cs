namespace WebApi_With_SQL_Server.Application.DTOs
{
    public class ProductQuery
    {
        public string? Search { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
