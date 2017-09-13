using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeatherDataService
{
    class OpenWeatherDataService : IWeatherDataService
    {
        private static OpenWeatherDataService WDS_Instance;
        private OpenWeatherDataService()
        {
            //SetWeatherData(d);

        }

        public WeatherData GetWeatherData(ref Location location)
        {
            string api, req;
            string key = "&mode=xml&appid=8831f24c29c57a97c2f15b8fbb340ef1";
            if(location.CityName != null)
            {
                req = "q=" + location.CityName;
            }
            else if(location.CityId != null)
            {
                req = "id=" + location.CityId;
            }
            else if(location.CoordLat != null && location.CoordLon != null)
            {
                req = "lon=" + location.CoordLon + "&lat=" + location.CoordLat;
            }
            else
            {
                throw new WeatherDataServiceException("location is empty");
                //SHOULD THROW EXCEPTION
            }
            api = "http://api.openweathermap.org/data/2.5/weather?" + req + key;
            try
            {
                XDocument reader = XDocument.Load(api);
                reader.Descendants("city").Select(p => new
                {
                    ref location.CityId = p.Attribute("id").Value,
                    ref location.CityName = p.Attribute("name").Value,
                    ref location.CoordLat = p.Attribute("lat").Value,
                    ref location.CoordLon = p.Attribute("lon").Value,
                    ref location.Country = p.Attribute("country").Value,
                    ref location.SunRise = p.Attribute("rise").Value,
                    ref location.SunSet = p.Attribute("set").Value,
                
                    //coord = p.Element("lon")
                }).ToList().ForEach(p =>
                {
                    Console.WriteLine("Id: " + p.id);
                    Console.WriteLine("Name: " + p.name);
                });
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception was occured\n" + ex.Message);
            }
            WeatherData data = new WeatherData(temperature:32.02, temperatureUnit: "celsius", humidity:100, humidityUnit:"%", pressure: 1023.6, pressureUnit: "hPa",
                windSpeed:2.6, windName:, cloudsName:"Light breeze", visibility: 10000, lastUpdate: "2017-09-13T16:50:00");
            return data;

        }
        public static OpenWeatherDataService Instance
        {
            get
            {
                if (WDS_Instance == null)
                    WDS_Instance = new OpenWeatherDataService();
                return WDS_Instance;
            }

        }
    }
}
