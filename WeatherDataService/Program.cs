using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using WeatherDataService;

namespace WeatherDataService
{
    class Program
    {
        /// <summary>
        /// This method is the one that we will execute
        /// when we will want to show the result of this project
        /// </summary>
        static void Main(string[] args)
        {
            try
            {

                Location location = new Location(cityName: "tel-aviv");
                WeatherDataServiceFactory factory = new WeatherDataServiceFactory();
                IWeatherDataService dataService = factory.GetWeatherDataService("open_weather_map");
                WeatherData weatherData = dataService.GetWeatherData(ref location);

                Console.WriteLine(location);
                Console.WriteLine(weatherData);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Main: Exception was occured\n"+ex.Message);
            }

            Console.ReadLine();
            return;
        }
    }
}
