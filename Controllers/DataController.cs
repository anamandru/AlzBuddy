using Microsoft.AspNetCore.Mvc;

namespace AlzBuddy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;

        public DataController(ILogger<DataController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        private IActionResult GetData()
        {
            try
            {
                // Replace the following line with your logic to retrieve the actual received message
                string receivedMessage = "Replace this with your actual logic to get the received message";

                Console.WriteLine($"Received message: {receivedMessage}");
                return Ok("Message processed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }

}
