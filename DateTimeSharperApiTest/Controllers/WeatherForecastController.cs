using DateTimeSharper;
using Microsoft.AspNetCore.Mvc;

namespace DateTimeSharperApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        public WeatherForecastController()
        {
        }
              

        [HttpGet(Name = "ConvertTimeZone")]
        public DateTime ConvertTimeZone(DateTime dateTime, TimeZoneEnum sourceTimeZoen, TimeZoneEnum destinationTimeZone)
        {
            return TimeZoneConverter.ConvertTime(dateTime, sourceTimeZoen, destinationTimeZone);
        }
    }
}
