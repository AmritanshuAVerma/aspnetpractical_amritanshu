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
}
