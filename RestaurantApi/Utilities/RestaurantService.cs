using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApi.Utilities
{
    public class RestaurantService
    {
        public IList<string> GetAvailableRestaurants(string day, string time)
        {
            var results = new List<string>();

            //resolve day to short hand form of day ignoring case
            day = ResolveDay(day);

            //resolve time
            var parsedTime = DateTime.Parse(time);

            //calculate restaurants model from csv this is a one time task
            var csvToJsonConvertor = new CsvToJsonConvertor();
            var restaurants = csvToJsonConvertor.GetJsonFromCsv();

            //loop through restaurants and add restaurants to end result that match search criteria
            foreach (var restaurant in restaurants)
            {
                var rest = restaurant.Availability.FirstOrDefault(x => x.Day.Equals(day, StringComparison.OrdinalIgnoreCase) 
                                                                       && parsedTime.TimeOfDay >= x.StartTime.TimeOfDay
                                                                       && parsedTime.TimeOfDay <= x.EndTime.TimeOfDay );

                if (rest != null)
                {
                    results.Add(restaurant.Name);
                }
            }

            return results;
        }

        private string ResolveDay(string day)
        {
            if (day.Equals("Monday", StringComparison.OrdinalIgnoreCase) ||
                day.Equals("Mon", StringComparison.OrdinalIgnoreCase))
            {
                return "Mon";
            }
            if (day.Equals("Tuesday", StringComparison.OrdinalIgnoreCase) ||
                day.Equals("Tue", StringComparison.OrdinalIgnoreCase))
            {
                return "Tue";
            }
            if (day.Equals("Wednesday", StringComparison.OrdinalIgnoreCase) ||
                day.Equals("Wed", StringComparison.OrdinalIgnoreCase))
            {
                return "Wed";
            }
            if (day.Equals("Thursday", StringComparison.OrdinalIgnoreCase) ||
                day.Equals("Thu", StringComparison.OrdinalIgnoreCase))
            {
                return "Thu";
            }
            if (day.Equals("Friday", StringComparison.OrdinalIgnoreCase) ||
                day.Equals("Fri", StringComparison.OrdinalIgnoreCase))
            {
                return "Fri";
            }
            if (day.Equals("Saturday", StringComparison.OrdinalIgnoreCase) ||
                day.Equals("Sat", StringComparison.OrdinalIgnoreCase))
            {
                return "Sat";
            }
            if (day.Equals("Sunday", StringComparison.OrdinalIgnoreCase) ||
                day.Equals("Sun", StringComparison.OrdinalIgnoreCase))
            {
                return "Sun";
            }

            return string.Empty;
        }
    }
}
