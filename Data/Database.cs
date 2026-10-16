using Microsoft.EntityFrameworkCore;

namespace Video_Game_API.Data
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {

        }
    }
}
