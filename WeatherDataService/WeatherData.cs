using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService
{
    class WeatherData
    {
        public double Temperature { get; set; }
        public string TemperatureUnit { get; set; }
        public double Humidity { get; set; }
        public string HumidityUnit { get; set; }
        public double Pressure { get; set; }
        public string PressureUnit { get; set; }
        public double WindSpeed { get; set; }
        public string WindName { get; set; }
        public string CloudsName { get; set; }
        public int Visibility { get; set; }
        public string LastUpdate { get; set; }

        public WeatherData(double temperature, string temperatureUnit,double humidity, string humidityUnit, double pressure, string pressureUnit,
            double windSpeed, string windName, string cloudsName, int visibility, string lastUpdate)
        {
            this.Temperature = temperature;
            this.TemperatureUnit = temperatureUnit;
            this.Humidity = humidity;
            this.HumidityUnit = humidityUnit;
            this.Pressure = pressure;
            this.PressureUnit = pressureUnit;
            this.WindSpeed = windSpeed;
            this.WindName = windName;
            this.CloudsName = cloudsName;
            this.Visibility = visibility;
            this.LastUpdate = lastUpdate;
    }
    }
}
