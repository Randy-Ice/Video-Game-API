using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Video_Game_API.Features.V1.Video_Games.DTO;

namespace Video_Game_API.Features.V1.Video_Games
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly Data.Database _db;
        public VideoGameController(Data.Database db)
        {
            _db = db;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var games = await _db.VideoGames
                .Include(x => x.Category)
                .ToListAsync();
            return Ok(games.Adapt<IEnumerable<GetVideoGameSimpleDTO>>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var game = await _db.VideoGames
                .Include(x => x.Category)
                .Include(x => x.Publisher)
                .Include(x => x.Developer)
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game.Adapt<GetVideoGameDetailsDTO>());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(PostVideoGameDTO dto)
        {
            var game = dto.Adapt<VideoGame>();
            await _db.AddAsync(game);
            await _db.SaveChangesAsync();
            var results = game.Adapt<GetVideoGameDetailsDTO>();
            return CreatedAtAction(nameof(GetById), new { id = game.Id }, results);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id, PutVideoGameDTO dto)
        {
            var game = await _db.VideoGames.FirstOrDefaultAsync(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            dto.Adapt(game);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var game = await _db.VideoGames.FirstOrDefaultAsync(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            _db.Remove(game);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
