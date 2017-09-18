using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataService
{
    /// <summary>
    /// This class describes location data
    /// </summary>
    public class Location
    {
        /// <params>
        /// These properties refers to the location data as they show in open website.
        /// </params>
        public int CityId { get; set; }
        public string CityName { get; set; }
        public double CoordLon { get; set; }
        public double CoordLat { get; set; }
        public string Country { get; set; }

        /// <summary>
        /// This method is constractor of location object by cityId
        /// </summary>
        public Location(int cityId)
        {
            this.CityId = cityId;
        }
        /// <summary>
        /// This method is constractor of location object by cityName
        /// </summary>
        public Location(string cityName)
        {
            this.CityName = cityName;
        }
        /// <summary>
        /// This method is constractor of location object by location coords
        /// </summary>
        public Location(double lon, double lat)
        {
            this.CoordLon = lon;
            this.CoordLat = lat;
        }

        /// <summary>
        /// This method overrides the ToString for represnting Location Object.
        /// </summary>
        public override string ToString()
        {
            string data = " City = " + CityName +", id = " + CityId
                + ", "+Country+" \n GeoCoords = [" + CoordLon + ", " + CoordLon +"]";
            return data;
        }
    }
}
