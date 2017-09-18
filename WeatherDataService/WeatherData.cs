using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService
{
    public class WeatherData : IComparable<WeatherData>
    {   
        public double Temperature { get; set; }
        public string TemperatureUnit { get; set; }
        public string LastUpdate { get; set; }
        public string Wind { get; set; }
        public string Cloudiness { get; set; }
        public double Pressure { get; set; }
        public string PressureUnit { get; set; }
        public double Humidity { get; set; }
        public string HumidityUnit { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        

        public WeatherData() { }

        public override string ToString()
        {
            string data = " Temperature = " + Temperature + ", unit = " + TemperatureUnit + ", "
                + ", \n LastUpdate = " + LastUpdate
                + ", \n Wind = " + Wind
                + ", \n Cloudiness = " + Cloudiness
                + ", \n Pressure = " + Pressure + ", unit = " + PressureUnit
                + ", \n Humidity = " + Humidity + HumidityUnit
                + ", \n Sunrise = " + Sunrise
                + ", \n Sunset = " + Sunset;
            return data;
        }
        public int CompareTo(WeatherData other)
        {
            return (int)(this.Temperature - other.Temperature);
        }
    }
}
