using CsvHelper.Configuration;

namespace RestaurantApi.Models
{
    public class RestaurantMap: ClassMap<Restaurant>
    {
        public string Name { get; set; }

        public string Availability { get; set; }
    }
}
