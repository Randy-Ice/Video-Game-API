namespace Video_Game_API.Features.V1.Video_Games.DTO
{
    public class GetVideoGameDetailsDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string? GameImage { get; set; }

        public Decimal Price { get; set; }
        public VideoGameCategoryDTO Category { get; set; }
        public VideoGameDeveloperDTO Developer { get; set; }
        public VideoGamePublisherDTO Publisher { get; set; }


        public List<VideoGameReviewsDTO> Reviews { get; set; } = new();


        public DateOnly ReleaseDate { get; set; }





    }
}

