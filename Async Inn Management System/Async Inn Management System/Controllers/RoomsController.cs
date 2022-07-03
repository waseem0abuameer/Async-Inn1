using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn_Management_System.Data;
using Async_Inn_Management_System.Models;
using Async_Inn_Management_System.Models.Interfaces;
using Async_Inn_Management_System.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Async_Inn_Management_System.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom room)
        {
            _room = room;
        }

        // GET: api/Rooms
        [HttpGet]
        [AllowAnonymous]

        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
            return Ok(await _room.GetRooms());
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        [AllowAnonymous]

        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            var room = await _room.GetRoom(id);

            return Ok(room);

        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = "Update Rooms")]

        public async Task<IActionResult> PutRoom(int id, RoomDTO room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }

            var updatedRoom = await _room.UpdateRoom(id, room);
            return Ok(updatedRoom);
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = "Create Rooms")]

        public async Task<ActionResult<RoomDTO>> PostRoom(RoomDTO room)
        {
            await _room.CreateRoom(room);
            return CreatedAtAction("GetRoom", new { id = room.ID }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "Delete Rooms")]

        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _room.DeleteRoom(id);
            return NoContent();
        }
        //Adds an amenity to a room
        [HttpPost]
        [Route("{roomId}/Amenity/{amenityId}")]
        [Authorize(Policy = "Add Amenity to Room")]

        public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
        {
            await _room.AddAmenityToRoom(roomId, amenityId);
            return NoContent();
        }
        //removes an amenity from a room
        [HttpDelete]
        [Route("{roomId}/{amenityId}")]
        [Authorize(Policy = "Delete Amenity From Room")]

        public async Task<IActionResult> DeleteAmenityFromRoom(int roomId, int amenityId)
        {
            await _room.RemoveAmentityFromRoom(roomId, amenityId);
            return NoContent();
        }

    }
}
