namespace JT_InfoApi.Domain.Entities
{
    public class Audit
    {
        public int Id { get; set; }
        public int? CustCode { get; set; }
        public string? MethodName { get; set; } = default!;
        public string? ControllerName { get; set; } = default!;
        public string HttpMethod { get; set; } = default!;
        public int StatusCode { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
