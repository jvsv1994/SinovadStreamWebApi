namespace SinovadDemo.Domain.Entities
{
    public class LinkedAccount:BaseEntity
    {
        public string AccessToken { get; set; }
        public int LinkedAccountTypeCatalogId { get; set; }
        public int LinkedAccountTypeCatalogDetailId { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

    }
}
