using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService
{
    class WeatherDataServiceException : ApplicationException
    {
        public WeatherDataServiceException(string str) : base(str)
        {
            Console.WriteLine("WeatherDataServiceException: "+str);
        }
    }
}
