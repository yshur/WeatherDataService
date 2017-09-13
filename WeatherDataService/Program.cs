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


    class WeatherDataServiceException : System.ApplicationException
    {
        public WeatherDataServiceException(string e)
        {
            Console.WriteLine(e);
        }

    }

    abstract class WeatherDataServiceFactory
    {
        public abstract IWeatherDataService GetWeatherDataService(string map);
        
    }
    class OpenWeatherFactory : WeatherDataServiceFactory
    {
        private OpenWeatherDataService service;
        private static string OPEN_WEATHER_MAP = "open_weather_map";
        public override IWeatherDataService GetWeatherDataService(string map)
        {
            return service;
        }
        
    }


    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                
                string location = "haifa";
                WebRequest request = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q="+location+"&mode=xml&appid=8831f24c29c57a97c2f15b8fbb340ef1");
                WebResponse response = request.GetResponse();
                Stream data = response.GetResponseStream();
                string result = String.Empty;
                using (StreamReader sr = new StreamReader(data))
                {
                    result = sr.ReadToEnd();
                }
                Console.WriteLine(result);
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(result);
                XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/weather?q=" + location + "&mode=xml&appid=8831f24c29c57a97c2f15b8fbb340ef1");
                while(reader.Read())
                {
                    Console.WriteLine(reader.Name+" "+reader.Value);

                }
                StringBuilder res = new StringBuilder();
                XDocument doc = XDocument.Load("http://api.openweathermap.org/data/2.5/weather?q=" + location + "&mode=xml&appid=8831f24c29c57a97c2f15b8fbb340ef1");
                var variables = from variable in doc.Descendants("temparature")
                                select new
                                {
                                    header = variable.Attribute("name").Value,
                                    Children = variable.Descendants("temprature")
                                };
                foreach(var variable in variables)
                {
                    res.AppendLine(variable.header);
                    foreach (var child in variable.Children)
                        res.AppendLine(" " + child.Attribute("name").Value);
                }

             
                    XDocument reader1 = XDocument.Load("http://api.openweathermap.org/data/2.5/weather?q=florida&mode=xml&appid=cc14653cd92959d4ad80b1cdca1ecac6");
                    reader1.Descendants("city").Select(p => new
                    {
                        id = p.Attribute("id").Value,
                        name = p.Attribute("name").Value
                        //coord = p.Element("lon")
                    }).ToList().ForEach(p =>
                    {
                        Console.WriteLine("Id: " + p.id);
                        Console.WriteLine("Name: " + p.name);
                    });
                    


                }
            catch (Exception ex)
            {
                Console.WriteLine("Exception was occured\n"+ex.Message);
            }

            Console.ReadLine();
            return;
        }
    }
}
