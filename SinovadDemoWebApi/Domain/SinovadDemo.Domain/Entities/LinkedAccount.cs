namespace SinovadDemo.Domain.Entities
{
    public class LinkedAccount:BaseEntity
    {
        public string SourceId { get; set; }
        public string LinkedAccountTypeCatalodId { get; set; }
        public string LinkedAccountTypeCatalodDetailId { get; set; }
        public string Email { get; set; }
        public string? AccessToken { get; set; }
        public string? IdToken { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

    }
}
