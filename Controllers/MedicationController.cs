using AlzBuddy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlzBuddy.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly AlzBuddyDB _alzBuddyDB;

        public MedicationController(AlzBuddyDB alzBuddyDB)
        {
            _alzBuddyDB = alzBuddyDB;
        }

        [HttpPost]
        public async Task<ActionResult<Medication>> AddMedication(Medication medication)
        {
            _alzBuddyDB.Add(medication);
            _alzBuddyDB.SaveChanges();
            return Ok(medication);
        }
    }
}
