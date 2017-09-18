using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService
{
    /// <summary>
    /// This class describes our exception.
    /// </summary>

    class WeatherDataServiceException : ApplicationException
    {
        /// <summary>
        /// This method is the constructor of our exception.
        /// it only print to the screen the message of the exception.
        /// </summary>
        public WeatherDataServiceException(string str) : base(str)
        {
            Console.WriteLine("WeatherDataServiceException: "+str);
        }
    }
}
