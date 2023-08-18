namespace SinovadDemo.Domain.Entities
{
    public class LinkedAccount:BaseEntity
    {
        public string AccessToken { get; set; }
        public int LinkedAccountProviderCatalogId { get; set; }
        public int LinkedAccountProviderCatalogDetailId { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

    }
}
