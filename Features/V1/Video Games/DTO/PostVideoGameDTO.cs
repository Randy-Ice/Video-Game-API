using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Video_Game_API.Features.V1.Video_Games.DTO
{
    public class PostVideoGameDTO
    {

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


        [Required]

        public DateOnly ReleaseDate { get; set; }





    }
}
