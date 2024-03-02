namespace URLShortener.WebApi.ResponseModels
{
    public class ErrorResponse
    {
        public string Title { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
    }
}
