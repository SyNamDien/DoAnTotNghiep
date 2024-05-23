using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebGiupViec_API.Models;

namespace WebGiupViec_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPaymentController : ControllerBase
    {
        private readonly WEBGIUPVIECContext _context;
        private readonly ILogger<JobPaymentController> _logger;

        public JobPaymentController(WEBGIUPVIECContext context, ILogger<JobPaymentController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobPayment>>> GetJobPayments()
        {
            return await _context.JobPayments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobPayment>> GetJobPayment(int id)
        {
            var jobPayment = await _context.JobPayments.FindAsync(id);

            if (jobPayment == null)
            {
                return NotFound();
            }

            return jobPayment;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobPayment(int id, JobPayment jobPayment)
        {
            if (id != jobPayment.JobPaymentId)
            {
                return BadRequest();
            }

            _context.Entry(jobPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobPaymentExists(id))
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
        public async Task<ActionResult<JobPayment>> PostJobPayment(JobPayment jobPayment)
        {
            try
            {
                // Kiểm tra tính hợp lệ của dữ liệu thanh toán (ModelState)
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // Trả về lỗi 400 Bad Request nếu dữ liệu không hợp lệ
                }

                _context.JobPayments.Add(jobPayment);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetJobPayment", new { id = jobPayment.JobPaymentId }, jobPayment);
            }
            catch (DbUpdateException ex) // Bắt lỗi cụ thể từ Entity Framework
            {
                _logger.LogError(ex, "Lỗi khi thêm thanh toán công việc vào cơ sở dữ liệu: {ErrorMessage}", ex.Message); // Ghi log chi tiết
                return StatusCode(500, "Lỗi khi xử lý thanh toán công việc. Vui lòng thử lại sau.");
            }
            catch (Exception ex) // Bắt các lỗi khác
            {
                _logger.LogError(ex, "Lỗi không xác định khi xử lý thanh toán công việc: {ErrorMessage}", ex.Message);
                return StatusCode(500, "Đã xảy ra lỗi khi xử lý thanh toán công việc."); // Thông báo lỗi tổng quát hơn
            }
        }
        
        [HttpGet("Job/{jobId}/Payments")]
        public async Task<ActionResult<IEnumerable<JobPayment>>> GetJobPaymentsByJobId(int jobId)
        {
            return await _context.JobPayments.Where(jp => jp.JobPaymentId == jobId).ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobPayment(int id)
        {
            var jobPayment = await _context.JobPayments.FindAsync(id);
            if (jobPayment == null)
            {
                return NotFound();
            }

            _context.JobPayments.Remove(jobPayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobPaymentExists(int id)
        {
            return _context.JobPayments.Any(e => e.JobPaymentId == id);
        }
    }
}
