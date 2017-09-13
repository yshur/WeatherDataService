using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService
{
    class Location
    {
        public long CityId { get; set; }
        public string CityName { get; set; }
        public double CoordLon { get; set; }
        public double CoordLat { get; set; }
        public string Country { get; set; }
        public string SunRise { get; set; }
        public string SunSet { get; set; }
        public Location(long cityId)
        {
            this.CityId = cityId;
        }
        public Location(string cityName)
        {
            this.CityName = cityName;
        }
        public Location(double lon, double lat)
        {
            this.CoordLon = lon;
            this.CoordLat = lat;
        }
        public Location(long cityId, string cityName, double lon, double lat, string country, string sunRise, string sunSet)
        {
            this.CityId = cityId;
            this.CityName = cityName;
            this.CoordLon = lon;
            this.CoordLat = lat;
            this.Country = country;
            this.SunRise = sunRise;
            this.SunSet = sunSet;
        }
    }
}
