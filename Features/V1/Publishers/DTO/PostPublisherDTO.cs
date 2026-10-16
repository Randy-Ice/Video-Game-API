using System.ComponentModel.DataAnnotations;

namespace Video_Game_API.Features.V1.Publishers.DTO
{
    public class PostPublisherDTO
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
    }
}
