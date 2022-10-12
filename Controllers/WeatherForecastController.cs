using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAPI.Services;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _service; 

        public WeatherForecastController(IWeatherService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<object> GetCurrentWeather([FromQuery]string lat = "44.34", [FromQuery]string lon = "10.99")
        {
            return await _service.Create(lat,lon); 
        }

    }
}
