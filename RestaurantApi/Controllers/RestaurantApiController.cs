using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public IEnumerable<Restaurant> Get()
        {
            var x = new CsvToJsonConvertor();
            var z = x.GetJsonFromCsv();
            return z.ToArray();
        }
    }
}
