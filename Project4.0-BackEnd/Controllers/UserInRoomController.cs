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
    public class UserInRoomController : ControllerBase
    {
        private readonly ProjectContext _context;

        public UserInRoomController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/UserInRoom
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInRoom>>> GetUserInRooms()
        {
            return await _context.UserInRooms.ToListAsync();
        }

        // GET: api/UserInRoom/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInRoom>> GetUserInRoom(int id)
        {
            var userInRoom = await _context.UserInRooms.FindAsync(id);

            if (userInRoom == null)
            {
                return NotFound();
            }

            return userInRoom;
        }

        [HttpGet("exists/{userID}/{roomID}")]
        public async Task<ActionResult<UserInRoom>> UserInRoomExists(int userID, int roomID)
        {
            var userInRoom = await _context.UserInRooms.Where(x => x.RoomID == roomID & x.UserID == userID).FirstOrDefaultAsync();

            if (userInRoom == null)
            {
                return null;
            }

            return userInRoom;
        }

        [HttpGet("room/{roomid}")]
        public async Task<ActionResult<IEnumerable<UserInRoom>>> GetAllUsersInRoom(int roomid)
        {
            return await _context.UserInRooms.Where(x => x.RoomID == roomid).ToListAsync();
        }

        // PUT: api/UserInRoom/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInRoom(int id, UserInRoom userInRoom)
        {
            if (id != userInRoom.UserInRoomID)
            {
                return BadRequest();
            }

            _context.Entry(userInRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInRoomExists(id))
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

        // POST: api/UserInRoom
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserInRoom>> PostUserInRoom(UserInRoom userInRoom)
        {

            _context.UserInRooms.Add(userInRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInRoom", new { id = userInRoom.UserInRoomID }, userInRoom);
        }

        // DELETE: api/UserInRoom/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserInRoom>> DeleteUserInRoom(int id)
        {
            var userInRoom = await _context.UserInRooms.FindAsync(id);
            if (userInRoom == null)
            {
                return NotFound();
            }

            _context.UserInRooms.Remove(userInRoom);
            await _context.SaveChangesAsync();

            return userInRoom;
        }

        private bool UserInRoomExists(int id)
        {
            return _context.UserInRooms.Any(e => e.UserInRoomID == id);
        }
    }
}
