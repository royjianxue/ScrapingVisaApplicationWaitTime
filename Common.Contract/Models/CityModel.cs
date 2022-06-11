using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contract.Models
{
    public class City
    {

        public string? CityName { get; set; }
        public string? CityId { get; set; }

    }

    public class CityModel
    {
        public List<City> Cities { get; set; } = new List<City>()
        {
            new City()
            {
                CityName = "Toronto",
                CityId = "P206"
            },

            new City()
            {
                CityName = "Ottawa",
                CityId = "P155"
            },
            new City()
            {
                CityName = "Calgary",
                CityId = "P43"
            },

            new City()
            {
                CityName = "Halifax",
                CityId = "P76"
            },
            
            new City()
            {
                CityName = "Montreal",
                CityId = "P137"
            },

            new City()
            {
                CityName = "Quebec",
                CityId = "P170"
            },
            new City()
            {
                CityName = "Vancourver",
                CityId = "P211"
            }
        };
    }

}
