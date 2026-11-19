using LabEquipmentApi.Contracts.Equipment;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabEquipmentApi.Data;
using LabEquipmentApi.Domain;

namespace LabEquipmentApi.Controllers
{
    [Route("api/equipment")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly LabDbContext _context;

        public EquipmentController(LabDbContext context)
        {
            _context = context;
        }

        // GET: api/Equipment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipmentItems()
        {
            return await _context.EquipmentItems.ToListAsync();
        }

        // GET: api/Equipment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> GetEquipment(int id)
        {
            var equipment = await _context.EquipmentItems.FindAsync(id);

            if (equipment == null)
            {
                return NotFound();
            }

            return equipment;
        }

        // PUT: api/Equipment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipment(int id, Equipment equipment)
        {
            if (id != equipment.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentExists(id))
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

        // POST: api/Equipment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equipment>> PostEquipment(Equipment equipment)
        {
            _context.EquipmentItems.Add(equipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipment", new { id = equipment.Id }, equipment);
        }

        // DELETE: api/Equipment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            var equipment = await _context.EquipmentItems.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }

            _context.EquipmentItems.Remove(equipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // GET: api/equipment/available
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<EquipmentListItemResponse>>> GetAvailableEquipment()
        {
            var equipment = await _context.EquipmentItems
                .Where(e => e.IsAvailable == true)
                .OrderBy(e => e.Name)
                .ProjectToType<EquipmentListItemResponse>()
                .ToListAsync();

            return Ok(equipment);
        }

        private bool EquipmentExists(int id)
        {
            return _context.EquipmentItems.Any(e => e.Id == id);
        }
    }
}
