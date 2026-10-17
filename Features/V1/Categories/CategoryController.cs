
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Video_Game_API.Features.V1.Categories.DTO;



namespace Video_Game_API.Features.V1.Categories
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Data.Database _db;
        public CategoryController(Data.Database db)
        {
            _db = db;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var category = await _db.Categories.ToListAsync();
            return Ok(category.Adapt<IEnumerable<GetCategoryDTO>>());
        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category.Adapt<GetCategoryDTO>());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(PostCategoryDTO dto)
        {
            var category = dto.Adapt<Category>();
            await _db.AddAsync(category);
            await _db.SaveChangesAsync();
            var results = category.Adapt<GetCategoryDTO>();
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, results);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id, PutCategoryDTO dto)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            dto.Adapt(category);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _db.Remove(category);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
