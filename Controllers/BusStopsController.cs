using Microsoft.AspNetCore.Mvc;

namespace BusStopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusStopsController : ControllerBase
    {
        private BusesSourceService busesSourceService;

        // Constructor
        public BusStopsController(BusesSourceService _busesSourceService)
        {
            busesSourceService = _busesSourceService;
        }

        [HttpGet("AllBusStops")]
        public async Task<IActionResult> Get()
        {
            var busStops = await busesSourceService.GetBusStopsAllAsync();
            return Ok(busStops);
        }
        [HttpGet("BusStopByCode/{code}")]
        public async Task<IActionResult> Get(string code)
        {
            var busStops = await busesSourceService.GetBusStopByCodeAsync(code);
            return Ok(busStops);
        }
    }
}
