namespace Video_Game_API.Features.V1.Developers.DTO
{
    public class GetDeveloperDetailsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public List<DeveloperGamesDTO> VideoGames { get; set; } = new();
    }
}
