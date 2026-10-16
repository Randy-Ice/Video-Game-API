using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Video_Game_API.Features.V1.Categories;
using Video_Game_API.Features.V1.Developers;
using Video_Game_API.Features.V1.Publishers;
using Video_Game_API.Features.V1.Reviews;

namespace Video_Game_API.Features.V1.Video_Games
{
    public class VideoGame
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string? GameImage { get; set; }
        [Required]
        [Precision(6, 2)]
        public Decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public Guid DeveloperId { get; set; }
        public Guid PublisherId { get; set; }

        public List<Review> Reviews { get; set; } = new();
        [Required]

        public DateOnly ReleaseDate { get; set; }




        //nav properties
        public Category Category { get; set; }
        public Developer Developer { get; set; }
        public Publisher Publisher { get; set; }

    }
}
