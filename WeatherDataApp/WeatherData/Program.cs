using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDataService;

namespace WeatherDataApp
{
    class Program
    {
        /// <summary>
        /// This method is the one that we will execute
        /// for show the result of WeatherDataservice project
        /// and use in WeatherDataservice library
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                string name;
                Console.WriteLine("Please type a city name");
                name = Console.ReadLine();

                Location location = new Location(cityName: name);
                WeatherDataServiceFactory factory = new WeatherDataServiceFactory();
                IWeatherDataService dataService = factory.GetWeatherDataService("open_weather_map");
                WeatherData weatherData = dataService.GetWeatherData(ref location);

                Console.WriteLine(location);
                Console.WriteLine(weatherData);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Main: Exception was occured\n" + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
