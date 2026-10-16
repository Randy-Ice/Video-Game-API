using Microsoft.EntityFrameworkCore;
using Video_Game_API.Features.V1.Categories;
using Video_Game_API.Features.V1.Developers;
using Video_Game_API.Features.V1.Publishers;
using Video_Game_API.Features.V1.Reviews;
using Video_Game_API.Features.V1.Video_Games;

namespace Video_Game_API.Data
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
