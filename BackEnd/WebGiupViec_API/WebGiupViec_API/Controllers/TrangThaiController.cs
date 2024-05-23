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
    public class TrangThaiController : ControllerBase
    {
        private readonly WEBGIUPVIECContext _context;

        public TrangThaiController(WEBGIUPVIECContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrangThai>>> GetTrangThais()
        {
            return await _context.TrangThais.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrangThai>> GetTrangThai(int id)
        {
            var trangThai = await _context.TrangThais.FindAsync(id);

            if (trangThai == null)
            {
                return NotFound();
            }

            return trangThai;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrangThai(int id, TrangThai trangThai)
        {
            if (id != trangThai.TrangThaiId)
            {
                return BadRequest();
            }

            _context.Entry(trangThai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrangThaiExists(id))
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
        public async Task<ActionResult<TrangThai>> PostTrangThai(TrangThai trangThai)
        {
            _context.TrangThais.Add(trangThai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrangThai", new { id = trangThai.TrangThaiId }, trangThai);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrangThai(int id)
        {
            var trangThai = await _context.TrangThais.FindAsync(id);
            if (trangThai == null)
            {
                return NotFound();
            }

            _context.TrangThais.Remove(trangThai);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrangThaiExists(int id)
        {
            return _context.TrangThais.Any(e => e.TrangThaiId == id);
        }
    }
}
