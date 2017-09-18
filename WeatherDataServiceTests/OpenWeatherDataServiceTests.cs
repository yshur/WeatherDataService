using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService.Tests
{
    [TestClass()]
    public class OpenWeatherDataServiceTests
    {

        [TestMethod()]
        public void GetWeatherDataTest()
        {
            Location location = new Location(cityName: "tel-aviv");
            int cityIdExpected = 293396;
            int cityIdActual;

            WeatherDataServiceFactory factory = new WeatherDataServiceFactory();
            IWeatherDataService dataService = factory.GetWeatherDataService("open_weather_map");
            WeatherData weatherData = dataService.GetWeatherData(ref location);

            cityIdActual = location.CityId;
            Assert.AreEqual(cityIdExpected, cityIdActual);
        }
    }
}