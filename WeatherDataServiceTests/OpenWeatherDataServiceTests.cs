using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService.Tests
{
    /// <summary>
    /// This is a test class for OpenWeatherDataService
    /// and is intended to contain a unit test only for 
    /// GetWeatherData method
    /// </summary>
    [TestClass()]
    public class OpenWeatherDataServiceTests
    {

        /// <summary>
        /// This is a unit test GetWeatherData method. 
        /// it compares between cityId after the executing 
        /// of this method.
        /// if they equal the test pass successfully.
        /// </summary>
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