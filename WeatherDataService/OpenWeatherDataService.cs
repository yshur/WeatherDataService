using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeatherDataService
{
    public class OpenWeatherDataService : IWeatherDataService
    { 
        private static OpenWeatherDataService openWeatherDataService;
        private OpenWeatherDataService() { }
        public static OpenWeatherDataService Instance()
        {
            if (openWeatherDataService == null)
                openWeatherDataService = new OpenWeatherDataService();
            return openWeatherDataService;
        }
        public WeatherData GetWeatherData(ref Location location)
        {
            try
            {
                WeatherData data = new WeatherData();
                string api, req;
                string key = "&mode=xml&units=metric&appid=8831f24c29c57a97c2f15b8fbb340ef1";
                if (location.CityName != null)
                {
                    req = "q=" + location.CityName;
                }
                else if (location.CityId != 0)
                {
                    req = "id=" + location.CityId;
                }
                else if (location.CoordLat != 0 && location.CoordLon != 0)
                {
                    req = "lon=" + location.CoordLon + "&lat=" + location.CoordLat;
                }
                else
                {
                    throw new WeatherDataServiceException("location is empty");
                }

                api = "http://api.openweathermap.org/data/2.5/weather?" + req + key;
                XDocument ob1 = XDocument.Load(api);
             //   Console.WriteLine(ob1);
                var item = from x in ob1.Descendants("city")
                           select x.Attribute("id").Value;
                location.CityId = int.Parse(item.First());
                item = from x in ob1.Descendants("city")
                       select x.Attribute("name").Value;
                location.CityName = item.First();
                item = from x in ob1.Descendants("country")
                       select x.Value;
                location.Country = item.First();
                item = from x in ob1.Descendants("coord")
                       select x.Attribute("lon").Value;
                location.CoordLon = double.Parse(item.First());
                item = from x in ob1.Descendants("coord")
                       select x.Attribute("lat").Value;
                location.CoordLat = double.Parse(item.First());
                //   Console.WriteLine(location);

                item = from x in ob1.Descendants("sun")
                       select x.Attribute("rise").Value;
                data.Sunrise = item.First();
                item = from x in ob1.Descendants("sun")
                       select x.Attribute("set").Value;
                data.Sunset = item.First();
                item = from x in ob1.Descendants("temperature")
                       select x.Attribute("value").Value;
                data.Temperature = double.Parse(item.First());
                item = from x in ob1.Descendants("temperature")
                       select x.Attribute("unit").Value;
                data.TemperatureUnit = item.First();
                item = from x in ob1.Descendants("humidity")
                       select x.Attribute("value").Value;
                data.Humidity = double.Parse(item.First());
                item = from x in ob1.Descendants("humidity")
                       select x.Attribute("unit").Value;
                data.HumidityUnit = item.First();
                item = from x in ob1.Descendants("pressure")
                       select x.Attribute("value").Value;
                data.Pressure = double.Parse(item.First());
                item = from x in ob1.Descendants("pressure")
                       select x.Attribute("unit").Value;
                data.PressureUnit = item.First();
                item = from x in ob1.Descendants("speed")
                       select x.Attribute("name").Value;
                data.Wind = item.First()+", ";
                item = from x in ob1.Descendants("speed")
                       select x.Attribute("value").Value;
                data.Wind += item.First()+" m/s, ";
                item = from x in ob1.Descendants("direction")
                       select x.Attribute("name").Value;
                data.Wind += item.First() + " ( ";
                item = from x in ob1.Descendants("direction")
                       select x.Attribute("value").Value;
                data.Wind += item.First() + " )";
                item = from x in ob1.Descendants("clouds")
                       select x.Attribute("name").Value;
                data.Cloudiness = item.First();
                item = from x in ob1.Descendants("lastupdate")
                       select x.Attribute("value").Value;
                data.LastUpdate = item.First();

               // Console.WriteLine(data);
                return data;
            }
            catch(Exception ex)
            {
                Console.WriteLine("OpenWeatherDataService: Exception was occured\n" + ex.Message);
                throw new WeatherDataServiceException(ex.Message);
            }
        }
    }
}
