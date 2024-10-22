using AlzBuddy.Models;
using AlzBuddy.Receivers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlzBuddy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly double currentTemperature;
        private readonly double currentCoPpm;
        private readonly int currentDoorOpenSeconds;
        private readonly int currentWaterLevel;
        public RoomController()
        {
            currentTemperature = Globals.currentTemperature;
            currentCoPpm = Globals.currentCoPpm;
            currentDoorOpenSeconds = Globals.currentDoorOpenSeconds;
            currentWaterLevel = Globals.currentWaterLevel;            
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(DataIncoming), 200)]
        public ActionResult<DataIncoming> Get()
        {
            // _logger.LogInformation($"Temp: {dataIncoming.temperature}, WaterLevel: {dataIncoming.waterLevel}, SecondsFridge: {dataIncoming.secondsFridge}, CoPpm: {dataIncoming.coPpm}");

            var data = new
            {
                temperature = Globals.currentTemperature,
                coPpm = Globals.currentCoPpm,
                secondsFridge = Globals.currentDoorOpenSeconds,
                waterLevel = Globals.currentWaterLevel
            };

            return Ok(data);
        }                
    }
}
