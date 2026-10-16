using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Video_Game_API.Features.V1.Video_Games.DTO
{
    public class PutVideoGameDTO
    {

        [Required]
        public string Description { get; set; }
        public string? GameImage { get; set; }
        [Required]
        [Precision(6, 2)]
        public Decimal Price { get; set; }




    }
}
