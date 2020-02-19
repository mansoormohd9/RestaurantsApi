using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace RestaurantApi.Models
{
    public class RestaurantMap: ClassMap<Restaurant>
    {
        public string Name { get; set; }

        public string Availability { get; set; }
    }
}
