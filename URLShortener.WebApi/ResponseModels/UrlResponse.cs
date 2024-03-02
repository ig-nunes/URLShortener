namespace URLShortener.WebApi.ResponseModels
{
    public class UrlResponse
    {
        public int Id { get; set; }
        public string ShortUrl { get; set; }
        public int ExpirationDate { get; set; }
    }
}
