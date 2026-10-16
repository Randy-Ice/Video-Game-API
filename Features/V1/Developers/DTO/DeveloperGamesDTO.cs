using System.ComponentModel.DataAnnotations;

namespace Video_Game_API.Features.V1.Developers.DTO
{
    public class DeveloperGamesDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DeveloperGameCategoryDTO Category { get; set; }
    }
}
