
#nullable disable

using SinovadDemo;

namespace SinovadDemo.Application.DTO
{
    public class AccountServerDto
    {
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public string AccountId { get; set; }
        public int StateCatalogId { get; set; }
        public int StateCatalogDetailId { get; set; }
        public string HostUrl { get; set; }
    }
}
