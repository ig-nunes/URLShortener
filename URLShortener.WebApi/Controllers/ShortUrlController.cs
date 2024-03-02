using Microsoft.AspNetCore.Mvc;
using URLShortener.Dados;
using URLShortener.Dados.CustomExceptions;
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
            var urls = await _repository.GetAll();
            return Ok(urls);
        }

        [HttpGet("{urlRequest}")]
        public async Task<IActionResult> GetUrl([FromRoute] string urlRequest)
        {
            var url = await _repository.Get(urlRequest);
            if (url == null)
            {
                throw new InvalidUrlException("URL encurtada inválida", 400);
            }

            if (url.IsExpired)
            {
                throw new InvalidUrlException("URL encurtada expirada", 400);
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url.LUrl);
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidUrlException($"URL original retornou o código de status {response.StatusCode}", (int) response.StatusCode);
            }

            return Redirect(url.LUrl);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UrlRequest request)
        {
            if (!Uri.TryCreate(request.Url, UriKind.Absolute, out var inputUrl))
            {
                return BadRequest("Foi passado um URL inválido");
            }

            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVXYZ1234567890@";
            var randomStr = new string(Enumerable.Repeat(chars, 8).Select(x => x[random.Next(x.Length)]).ToArray());

            var url = new Url()
            {
                LUrl = request.Url,
                SUrl = randomStr,
                CreationDate = DateTime.Now,
                ExpirationPeriod = 3000
            };

            await _repository.Post(url);

            return Ok(new UrlResponse
            {
                Id = url.Id,
                ShortUrl = "http://localhost:5048/ShortUrl/" + url.SUrl,
                ExpirationDate = url.TimeRemainingInSeconds()
            });
        }

        [HttpDelete("{url}")]
        public async Task<IActionResult> DeleteUrl(string url)
        {
            await _repository.Delete(url);
            return Ok($"URL '{url}' Deletado com sucesso");
        }
    }
}
