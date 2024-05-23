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
    public class PostController : ControllerBase
    {
        private readonly WEBGIUPVIECContext _context;
        private readonly ILogger<PostController> _logger; // Sửa lại ILogger

        public PostController(WEBGIUPVIECContext context, ILogger<PostController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.PostId)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            try
            {
                if (!ModelState.IsValid) // Kiểm tra ModelState
                {
                    return BadRequest(ModelState); // Trả về lỗi 400 Bad Request nếu dữ liệu không hợp lệ
                }

                _context.Posts.Add(post);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPost", new { id = post.PostId }, post);
            }
            catch (DbUpdateException ex) // Bắt lỗi cụ thể hơn từ Entity Framework
            {
                _logger.LogError(ex, "Lỗi khi thêm bài viết vào cơ sở dữ liệu: {ErrorMessage}", ex.Message); // Ghi log chi tiết
                return StatusCode(500, "Lỗi khi thêm bài viết. Vui lòng thử lại.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi không xác định khi thêm bài viết: {ErrorMessage}", ex.Message);
                return StatusCode(500, "Đã xảy ra lỗi. Vui lòng thử lại sau.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
