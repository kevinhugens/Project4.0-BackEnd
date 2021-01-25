using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project4._0_BackEnd.Data;
using Project4._0_BackEnd.Models;

namespace Project4._0_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPollController : ControllerBase
    {
        private readonly ProjectContext _context;

        public UserPollController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/UserPoll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPoll>>> GetUserPolls()
        {
            return await _context.UserPolls.ToListAsync();
        }

        // GET: api/UserPoll/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPoll>> GetUserPoll(int id)
        {
            var userPoll = await _context.UserPolls.FindAsync(id);

            if (userPoll == null)
            {
                return NotFound();
            }

            return userPoll;
        }

        // PUT: api/UserPoll/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPoll(int id, UserPoll userPoll)
        {
            if (id != userPoll.UserPollID)
            {
                return BadRequest();
            }

            _context.Entry(userPoll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPollExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserPoll
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserPoll>> PostUserPoll(UserPoll userPoll)
        {
            _context.UserPolls.Add(userPoll);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPoll", new { id = userPoll.UserPollID }, userPoll);
        }

        // DELETE: api/UserPoll/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserPoll>> DeleteUserPoll(int id)
        {
            var userPoll = await _context.UserPolls.FindAsync(id);
            if (userPoll == null)
            {
                return NotFound();
            }

            _context.UserPolls.Remove(userPoll);
            await _context.SaveChangesAsync();

            return userPoll;
        }

        private bool UserPollExists(int id)
        {
            return _context.UserPolls.Any(e => e.UserPollID == id);
        }
    }
}
