using System.ComponentModel.DataAnnotations;

namespace Video_Game_API.Features.V1.Categories.DTO
{
    public class PutCategoryDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "At least 3 characters in length")]
        public string Name { get; set; }
    }
}
