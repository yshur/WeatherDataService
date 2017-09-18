using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService
{
    /// <summary>
    /// This class is responsible for Get WeatherDataService by parameter of map.
    /// it return WeatherDataService that link to the map parameter.
    /// if map parameter unknown it throw WeatherDataServiceException.
    /// </summary>
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
