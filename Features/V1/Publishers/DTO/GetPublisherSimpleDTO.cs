namespace Video_Game_API.Features.V1.Publishers.DTO
{
    public class GetPublisherSimpleDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }


    }
}
