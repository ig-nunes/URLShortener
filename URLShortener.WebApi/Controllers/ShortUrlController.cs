using Microsoft.AspNetCore.Mvc;
using URLShortener.Dados;
using URLShortener.Dados.Models;
using URLShortener.WebApi.RequestModels;
using URLShortener.WebApi.ResponseModels;

namespace URLShortener.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortUrlController : Controller
    {
        private readonly IRepository _repository;

        public ShortUrlController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUrls()
        {
            var urls = await _repository.GetAllUrlsAsync();
            return Ok(urls);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UrlRequest request)
        {
            if (!Uri.TryCreate(request.Url , UriKind.Absolute, out var inputUrl))
            {
                Results.BadRequest("invalid url has been profifafed");
            }

            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVXYZ1234567890@";
            var randomStr = new string(Enumerable.Repeat(chars, 8).Select(x => x[random.Next(x.Length)]).ToArray());

            var url = new Url()
            {
                LUrl = request.Url,
                SUrl = randomStr,
                CreationDate = DateTime.Now,
                ExpirationPeriod = 300
            };

            await _repository.Post(url);
            
            return Ok(new UrlResponse
            {
                Id = url.Id,
                ShortUrl = url.SUrl,
                ExpirationDate = url.TimeRemainingInSeconds()
            });
        }
    }
}
