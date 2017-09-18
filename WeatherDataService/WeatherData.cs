using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService
{
    /// <summary>
    /// This class is responsible for presenting weather data
    /// It implement IComparable interface for using in linq with "desendants" method.
    /// </summary>
    public class WeatherData : IComparable<WeatherData>
    {
        /// <params>
        /// These properties refers to the weather data as they show in open website.
        /// </params>
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

        /// <summary>
        /// This method overrides the ToString for represnting WeatherData Object.
        /// </summary>
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
        /// <summary>
        /// This method compares between two WeatherData Objects by their Temperature field.
        /// Implementing CompareTo for using in linq with "desendants" method.
        /// </summary>
        public int CompareTo(WeatherData other)
        {
            return (int)(this.Temperature - other.Temperature);
        }
    }
}
