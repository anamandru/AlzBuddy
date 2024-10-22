using AlzBuddy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlzBuddy.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PacientController : ControllerBase
    {
        private readonly AlzBuddyDB _alzBuddyDB;

        public PacientController(AlzBuddyDB alzBuddyDB)
        {
            _alzBuddyDB = alzBuddyDB;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Pacient>> GetAll()
        {
            var accounts = _alzBuddyDB.Pacients;
            return accounts;
        }

        [HttpPost]
        public async Task<ActionResult<Pacient>> AddPacient(Pacient pacient)
        {
            _alzBuddyDB.Add(pacient);
            _alzBuddyDB.SaveChanges();
            return Ok(pacient);
        }

        [HttpDelete]
        public async Task<ActionResult<Pacient>> DeletePacient(int id)
        {
            Pacient? findPacient = _alzBuddyDB.Pacients
        .Include(p => p.Medications)
        .Include(p => p.Doctor)
        .FirstOrDefault(p => p.Id == id);

            if (findPacient == null)
            {
                return NotFound();
            }

            // Remove the pacient (and related entities will be deleted due to cascading delete)
            _alzBuddyDB.Doctors.Remove(findPacient.Doctor);
            _alzBuddyDB.Medication.Remove(findPacient.Medications[0]);
            _alzBuddyDB.Pacients.Remove(findPacient);
            

            UsersPacients? findUsersPacient = _alzBuddyDB.UsersPacients.FirstOrDefault(m => m.PacientId == id);

            if (findUsersPacient != null)
            {
                _alzBuddyDB.UsersPacients.Remove(findUsersPacient);
            }

            _alzBuddyDB.SaveChanges();
            return Ok(id);
        }

        [HttpPost]
        public async Task<ActionResult<Pacient>> EditPacient(Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                _alzBuddyDB.Entry(pacient).State = EntityState.Modified;
                _alzBuddyDB.SaveChanges();
            }

            return Ok(pacient);
        }

        [HttpGet]
        public async Task<ActionResult<Pacient>> GetById(int id)
        {
            var pacient = await _alzBuddyDB.Pacients.Include(p => p.Medications).Include(p => p.Doctor).Where(u => u.Id == id).FirstOrDefaultAsync();
            return pacient;
        }

    }
}
