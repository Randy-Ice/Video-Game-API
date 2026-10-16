namespace Video_Game_API.Features.V1.Video_Games.DTO
{
    public class GetVideoGameSimpleDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


        public string? GameImage { get; set; }

        public VideoGameCategoryDTO Category { get; set; }



        public DateOnly ReleaseDate { get; set; }





    }
}

