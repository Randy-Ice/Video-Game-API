using System.ComponentModel.DataAnnotations;

namespace Video_Game_API.Features.V1.Reviews.DTO
{
    public class PutReviewDTO
    {


        [Required]
        [MinLength(15, ErrorMessage = "Description should be more than 15 characters in length")]
        public string Description { get; set; }



    }
}
