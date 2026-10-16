using System.ComponentModel.DataAnnotations;

namespace Video_Game_API.Features.V1.Publishers.DTO
{
    public class PublisherGamesDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public PublisherGameCategoryDTO Category { get; set; }
    }
}
