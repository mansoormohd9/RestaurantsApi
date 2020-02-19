using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace RestaurantApi.Utilities
{
    public class CsvToJsonConvertor
    {
        public IList<Restaurant> GetJsonFromCsv()
        {
            var temp = Directory.GetCurrentDirectory();
            using (var reader = new StreamReader(Directory.GetCurrentDirectory() + "\\Utilities\\CSV\\Restaurants.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = false;
                var restaurants = csv.GetRecords<Restaurant>().ToList();
                return restaurants;
            }
        }
    }
}
