using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantApi.Models;
using RestaurantApi.Utilities;

namespace RestaurantApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantApiController : ControllerBase
    {
        private readonly ILogger<RestaurantApiController> _logger;

        public RestaurantApiController(ILogger<RestaurantApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IList<string> Get(string day, string time)
        {
            var helperService = new RestaurantService();
            return helperService.GetAvailableRestaurants(day, time);
        }
    }
}
