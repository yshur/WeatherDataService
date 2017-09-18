using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService
{
    public class WeatherDataServiceFactory
    {
        private OpenWeatherDataService openService = OpenWeatherDataService.Instance();
        private const string OPEN_WEATHER_MAP = "open_weather_map";
        public WeatherDataServiceFactory() { }
        public IWeatherDataService GetWeatherDataService(string map)
        {
            switch (map)
            {
                case OPEN_WEATHER_MAP:
                    return openService;
                default:
                    throw new WeatherDataServiceException("Unvalid Map for WeatherDataService");
            }
        }
    }
}
