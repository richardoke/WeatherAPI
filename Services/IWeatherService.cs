using System.Threading.Tasks;

namespace WeatherAPI.Services
{
    public interface IWeatherService
    {
        Task<object> Create(string lat, string lon);
   }
}
