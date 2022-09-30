namespace AlbumAPI.Model
{
    public class ErrorModel
    {
        public int Id { get; set; }

        public string? ErrorType { get; set; }

        public string? ErrorName { get; set; }

        public string? ErrorDescription { get; set; }

        public int LineNumber { get; set; }

        public string? ApiId { get; set; }
    }

    public class ErrorDetails
    {
        public int StatusCode { get; set; }

        public string? Message { get; set; } = String.Empty;
    }
}
