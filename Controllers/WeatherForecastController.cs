using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GenericApi.Controllers
{
    [ApiController]
    [Route("api/weather-forecast")]
    public class WeatherForecastController : BaseController<WeatherForecast>
    {
        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(DBContext context, ILogger<WeatherForecastController> logger): base(context)
        {
            _logger = logger;
        }
    }
}
