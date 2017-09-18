using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService
{
    public class Location
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public double CoordLon { get; set; }
        public double CoordLat { get; set; }
        public string Country { get; set; }

        public Location(int cityId)
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
        public override string ToString()
        {
            string data = " City = " + CityName +", id = " + CityId
                + ", "+Country+" \n GeoCoords = [" + CoordLon + ", " + CoordLon +"]";
            return data;
        }
    }
}
