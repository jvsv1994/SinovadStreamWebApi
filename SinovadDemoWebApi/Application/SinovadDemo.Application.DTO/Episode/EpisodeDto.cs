namespace SinovadDemo.Application.DTO.Episode
{
    public class EpisodeDto
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public int? EpisodeNumber { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }


    }
}
