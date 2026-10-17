using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Video_Game_API.Features.V1.Developers.DTO;

namespace Video_Game_API.Features.V1.Developers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly Data.Database _db;
        public DeveloperController(Data.Database db)
        {
            _db = db;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var developer = await _db.Developers.ToListAsync();
            return Ok(developer.Adapt<IEnumerable<GetDeveloperSimpleDTO>>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var developer = await _db.Developers
                .Include(x => x.VideoGames)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (developer == null)
            {
                return NotFound();
            }
            return Ok(developer.Adapt<GetDeveloperDetailsDTO>());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(PostDeveloperDTO dto)
        {
            var developer = dto.Adapt<Developer>();
            await _db.AddAsync(developer);
            await _db.SaveChangesAsync();
            var results = developer.Adapt<GetDeveloperDetailsDTO>();
            return CreatedAtAction(nameof(GetById), new { id = developer.Id }, results);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id, PutDeveloperDTO dto)
        {
            var developer = await _db.Developers.FirstOrDefaultAsync(x => x.Id == id);
            if (developer == null)
            {
                return NotFound();
            }
            dto.Adapt(developer);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var developer = await _db.Developers.FirstOrDefaultAsync(x => x.Id == id);
            if (developer == null)
            {
                return NotFound();
            }
            _db.Remove(developer);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
