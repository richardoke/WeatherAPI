using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherAPI.Entities;
using WeatherAPI.Repository.Generic;

namespace WeatherAPI.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IGenericRepository<WeatherCity> _repository;
        private readonly IHttpClientFactory _factory;
        public WeatherService(IGenericRepository<WeatherCity> repository, IHttpClientFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }


        public async Task<object> Create(string lat, string lon)
        {
            var weather_url = "https://api.openweathermap.org/data/2.5/weather?lat="+ $"{lat}&lon={lon}&appid=0e04e12934b32dcde3fe2577926979b1";

            var client = _factory.CreateClient();

            HttpResponseMessage response = await client.GetAsync(weather_url);

            string responseJson = await response.Content.ReadAsStringAsync();

            var _wd = await _repository.Query().FirstOrDefaultAsync(x => x.Lat == lat && x.Lon == lon);

            if (_wd != null)
            {
                return new { message = "Data already exist" };
            }

            var _d = new WeatherCity()
            {
                Lat = lat,
                Lon = lon,
                WeatherData = responseJson
            };

            await _repository.Add(_d);
            await _repository.Save();

            var _wdt = _repository.Query();

            return new { 
                message = "Data saved successfully",
                data = _wdt
            };
        }
    }
}
