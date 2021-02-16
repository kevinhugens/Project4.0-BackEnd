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
    public class RoomController : ControllerBase
    {
        private readonly ProjectContext _context;
        private TimeZoneInfo myTimeZone = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");

        public RoomController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Room
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await _context.Rooms.Include(x => x.Moderator).Include(y=>y.Presentator).ToListAsync();
        }
        [HttpGet("week")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllRoomsForThisWeek()
        {
            var currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, myTimeZone);
            DateTime endDate = currentDateTime.AddDays(7);
            return await _context.Rooms.Where(a=> a.Published == true & a.StartStream>= currentDateTime & a.StartStream<=endDate).Include(x => x.Moderator).Include(y => y.Presentator).OrderBy(z => z.StartStream).ToListAsync();
        }
        [HttpGet("live")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllLive()
        {
            return await _context.Rooms.Where(a => a.Live == true).Include(x => x.Moderator).Include(y => y.Presentator).OrderBy(z => z.StartStream).ToListAsync();
        }
        [HttpGet("islive/{roomid}")]
        public async Task<ActionResult<Boolean>> IsRoomLive(int roomid)
        {
            var room = await _context.Rooms.Where(y => y.RoomID == roomid).FirstOrDefaultAsync();
            if (room == null)
            {
                return NotFound();
            }
            if (room.Live == false)
            {
                return false;
            }
            return true;
        }


        [HttpGet("presentator/{presentatorID}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllRoomsFromPresentatorToManage(int presentatorID)
        {
            var currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, myTimeZone);
            return await _context.Rooms.Where(a => (a.EndStream >= currentDateTime | a.Live == true) & a.PresentatorID == presentatorID).Include(x => x.Moderator).Include(y => y.Presentator).OrderBy(z=>z.StartStream).ToListAsync();
        }
        [HttpGet("history")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllRoomsFromHistory()
        {
            var currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, myTimeZone);
            return await _context.Rooms.Where(a => a.EndStream <= currentDateTime).Include(y => y.Presentator).OrderByDescending(z => z.StartStream).ToListAsync();
        }
        [HttpGet("history/{presentatorID}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllRoomsFromHistoryFromPresentator(int presentatorID)
        {
            var currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, myTimeZone);
            return await _context.Rooms.Where(a => a.PresentatorID == presentatorID & a.EndStream <= currentDateTime).Include(x => x.Moderator).Include(y => y.Presentator).OrderByDescending(z => z.StartStream).ToListAsync();
        }

        // GET: api/Room/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _context.Rooms.Include(x => x.Moderator).Include(y=>y.Presentator).Where(y => y.RoomID == id).FirstOrDefaultAsync();

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Room/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.RoomID)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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

        // POST: api/Room
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.RoomID }, room);
        }

        // DELETE: api/Room/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return room;
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.RoomID == id);
        }
    }
}
