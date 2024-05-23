using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebGiupViec_API.Models;

namespace WebGiupViec_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly WEBGIUPVIECContext _context;

        public StaffController(WEBGIUPVIECContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<staff>>> Getstaff()
        {
            return await _context.staff.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<staff>> Getstaff(int id)
        {
            var staff = await _context.staff.FindAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            return staff;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Putstaff(int id, staff staff)
        {
            if (id != staff.StaffId)
            {
                return BadRequest();
            }

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!staffExists(id))
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

        [HttpPost]
        public async Task<ActionResult<staff>> Poststaff(staff staff)
        {
            _context.staff.Add(staff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getstaff", new { id = staff.StaffId }, staff);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletestaff(int id)
        {
            var staff = await _context.staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            _context.staff.Remove(staff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool staffExists(int id)
        {
            return _context.staff.Any(e => e.StaffId == id);
        }
    }
}
