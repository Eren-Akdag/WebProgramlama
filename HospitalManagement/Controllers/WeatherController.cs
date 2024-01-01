// System.Net.Http, System.Threading.Tasks ve Microsoft.AspNetCore.Mvc isim alanlarını kullanıyoruz.
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// YourNamespace.Controllers isim alanı içerisindeyiz.
namespace HospitalManagement.Controllers
{
    // WeatherController sınıfımız bir ControllerBase'dir.
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        // IHttpClientFactory tipinde bir özel alan tanımlanmıştır.
        private readonly IHttpClientFactory _clientFactory;

        // Yapıcı metot ile IHttpClientFactory tipindeki nesne enjekte edilmiştir.
        public WeatherController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // HTTP GET metodu ile belirli bir şehrin hava durumunu almak için bir işlem.
        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            // OpenWeatherMap API'sine bir istek oluşturuyoruz.
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=adcbe07e0f9e133635008638621c5382");

            // Bir HttpClient oluşturuyoruz.
            var client = _clientFactory.CreateClient();

            // İsteği gönderiyoruz ve yanıtı alıyoruz.
            var response = await client.SendAsync(request);

            // Eğer yanıt başarılıysa, yanıtın içeriğini okuyoruz ve Ok() ile döndürüyoruz.
            if (response.IsSuccessStatusCode)
            {
                return Ok(await response.Content.ReadAsStringAsync());
            }

            // Yanıt başarılı değilse, BadRequest() döndürülür.
            return BadRequest();
        }
    }
}
