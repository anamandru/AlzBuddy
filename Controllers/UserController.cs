using AlzBuddy.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AlzBuddy.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly AlzBuddyDB _alzBuddyDB;


        public UserController(AlzBuddyDB alzBuddyDB)
        {
            _alzBuddyDB = alzBuddyDB;
        }
        [HttpGet]
        public ActionResult<IEnumerable<AccountUser>> GetAll()
        {
            var accounts = _alzBuddyDB.AccountUsers;
            return accounts;
        }

        [HttpPost]
        public async Task<ActionResult<AccountUser>> AddUser(AccountUser user)
        {
            _alzBuddyDB.Add(@user);
            _alzBuddyDB.SaveChanges();
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<AccountUser>> GetByEmail(string email)
        {
            var user = await _alzBuddyDB.AccountUsers.Where(u => u.Email == email).FirstOrDefaultAsync();
            return user;
        }

    }
}
