using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Entities
{
    public class WeatherCity : Entity
    {
        public string Lon { get; set; }
        public string Lat { get; set; }
        public string WeatherData { get; set; }
    }
}
