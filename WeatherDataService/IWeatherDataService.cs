using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService
{
    interface IWeatherDataService
    {
        WeatherData GetWeatherData(ref Location location);
    }
}
