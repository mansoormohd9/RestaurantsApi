using System.Collections.Generic;

namespace RestaurantApi.Models
{
    public class Restaurant
    {
        public string Name { get; set; }

        public IList<AvailabilityTime> Availability { get; set; }
    }
}
