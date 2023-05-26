namespace ApiAuthor.Dtos
{
    public class ResponseDto
    {
        public int statusCode { get; set; }
        public string? message { get; set; }
        public bool isError { get; set; }
    }
}
