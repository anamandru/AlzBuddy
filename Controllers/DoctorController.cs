using AlzBuddy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlzBuddy.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly AlzBuddyDB _alzBuddyDB;

        public DoctorController(AlzBuddyDB alzBuddyDB)
        {
            _alzBuddyDB = alzBuddyDB;
        }

        [HttpPost]
        public async Task<ActionResult<Doctor>> AddDoctor(Doctor doctor)
        {
            _alzBuddyDB.Add(doctor);
            _alzBuddyDB.SaveChanges();
            return Ok(doctor);
        }
    }
}
