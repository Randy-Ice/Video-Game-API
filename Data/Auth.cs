using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Video_Game_API.Data
{
    public class Auth : IdentityDbContext<IdentityUser>
    {
        public Auth(DbContextOptions<Auth> options) : base(options)
        {

        }

    }
}
