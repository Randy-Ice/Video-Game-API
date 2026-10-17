using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Video_Game_API.Features.V1.Publishers.DTO;

namespace Video_Game_API.Features.V1.Publishers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly Data.Database _db;
        public PublisherController(Data.Database db)
        {
            _db = db;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var publiser = await _db.Publishers.ToListAsync();
            return Ok(publiser.Adapt<IEnumerable<GetPublisherSimpleDTO>>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var publisher = await _db.Publishers
                .Include(x => x.VideoGames)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (publisher == null)
            {
                return NotFound();
            }
            return Ok(publisher.Adapt<GetPublisherDetailsDTO>());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(PostPublisherDTO dto)
        {
            var publisher = dto.Adapt<Publisher>();
            await _db.AddAsync(publisher);
            await _db.SaveChangesAsync();
            var results = publisher.Adapt<GetPublisherDetailsDTO>();
            return CreatedAtAction(nameof(GetById), new { id = publisher.Id }, results);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id, PutPublisherDTO dto)
        {
            var publisher = await _db.Publishers.FirstOrDefaultAsync(x => x.Id == id);
            if (publisher == null)
            {
                return NotFound();
            }
            dto.Adapt(publisher);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var publisher = await _db.Publishers.FirstOrDefaultAsync(x => x.Id == id);
            if (publisher == null)
            {
                return NotFound();
            }
            _db.Remove(publisher);
            await _db.SaveChangesAsync();
            return NoContent();
        }

    }
}
