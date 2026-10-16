using System.ComponentModel.DataAnnotations;

namespace Video_Game_API.Features.V1.Reviews.DTO
{
    public class PostReviewDTO
    {

        [Required]
        public string User { get; set; }
        [Required]
        [MinLength(15, ErrorMessage = "Description should be more than 15 characters in length")]
        public string Description { get; set; }
        [Required]

        public Guid VideoGameId { get; set; }

    }
}
