using System.ComponentModel.DataAnnotations;
using Video_Game_API.Features.V1.Video_Games;

namespace Video_Game_API.Features.V1.Developers
{
    public class Developer
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }


        public string? Description { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        public List<VideoGame> VideoGames { get; set; } = new();

    }
}
