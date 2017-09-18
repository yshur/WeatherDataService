using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService
{
    /// <summary>
    /// This interface is responsible for Get current WeatherData by location. 
    /// </summary>
    public interface IWeatherDataService
    {
        /// <summary>
        /// This method returns WeatherData Object
        /// and also update location object.
        /// so location parameter should be reference to original location object. 
        /// </summary>
        WeatherData GetWeatherData(ref Location location);
    }
}
