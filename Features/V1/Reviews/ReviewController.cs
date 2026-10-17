using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Video_Game_API.Features.V1.Reviews.DTO;

namespace Video_Game_API.Features.V1.Reviews
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly Data.Database _db;
        public ReviewController(Data.Database db)
        {
            _db = db;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Post(PostReviewDTO dto)
        {
            var review = dto.Adapt<Review>();
            await _db.AddAsync(review);
            await _db.SaveChangesAsync();
            return NoContent();

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Put(Guid id, PutReviewDTO dto)
        {
            var review = await _db.Reviews.FirstOrDefaultAsync(x => x.Id == id);
            if (review == null)
            {
                return NotFound();
            }
            dto.Adapt(review);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var review = await _db.Reviews.FirstOrDefaultAsync(x => x.Id == id);
            if (review == null)
            {
                return NotFound();
            }
            _db.Remove(review);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
