using System.Collections.Generic;

namespace RestaurantApi.Models
{
    public class Restaurant
    {
        public string Name { get; set; }

        public IDictionary<string, AvailabilityTime> Availability { get; set; }
    }
}
