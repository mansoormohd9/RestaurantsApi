﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CsvHelper;
using RestaurantApi.Models;

namespace RestaurantApi.Utilities
{
    public class CsvToJsonConvertor
    {
        public IList<Restaurant> GetJsonFromCsv()
        {
            var restaurants = new List<Restaurant>();
            using (var reader = new StreamReader(Directory.GetCurrentDirectory() + "\\Utilities\\CSV\\Restaurants.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = false;
                var restList = csv.GetRecords<RestaurantMap>().ToList();
                foreach (var restaurant in restList)
                {
                    restaurants.Add(new Restaurant{ Name = restaurant.Name, Availability = GetAvailabilityDictionary(restaurant.Availability) });
                }

                return restaurants;
            }
        }

        private IList<AvailabilityTime> GetAvailabilityDictionary(string restaurantAvailability)
        {
            var availabilityTime = new List<AvailabilityTime>();

            var contDaysRegex = new Regex("([A-Z]\\w+-[A-Z]\\w+)");
            var daysRegex = new Regex("([^-])([A-Z]\\w+)([^-])");
            var timeRegex = new Regex("([0-9]+(:[0-9]+)?(\\s)+[aApP][mM])");

            foreach (var avb in restaurantAvailability.Split('/'))
            {
                var availability = avb.Trim();
                var contDays = contDaysRegex.Matches(availability);
                var days = daysRegex.Matches(availability);
                var time = timeRegex.Matches(availability);

                if (days.Count > 0)
                {
                    foreach (var day in days)
                    {
                        availabilityTime.Add(new AvailabilityTime
                        {
                            Day = day.ToString().Trim(),
                            StartTime = DateTime.Parse(time[0].Value),
                            EndTime = DateTime.Parse(time[1].Value)
                        });
                    }
                }

                var daysList = new List<string> {"Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"};
                ;
                foreach (var contDay in contDays)
                {
                    var contDaySplit = contDay.ToString().Split('-');
                    var foundMatch = false;
                    foreach (var day in daysList)
                    {
                        if (day.Trim().Equals(contDaySplit[0], StringComparison.OrdinalIgnoreCase))
                        {
                            foundMatch = !foundMatch;
                        }
                    
                        if (foundMatch)
                        {
                            availabilityTime.Add(new AvailabilityTime
                            {
                                Day = day.Trim(),
                                StartTime = DateTime.Parse(time[0].Value),
                                EndTime = DateTime.Parse(time[1].Value)
                            });
                        }
                    
                        if (day.Trim().Equals(contDaySplit[1], StringComparison.OrdinalIgnoreCase))
                        {
                            break;
                        }
                    }

                }
            }

            return availabilityTime;
        }
    }
}
