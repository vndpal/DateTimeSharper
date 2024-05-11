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

        [HttpGet(Name = "GetCurrentDateTime")]
        public DateTime Get()
        {
            return DateTimeSharper.DateTimeSharper.getCurrentDateTime(DateTimeSharper.TimeZone.Ist);
        }
    }
}
