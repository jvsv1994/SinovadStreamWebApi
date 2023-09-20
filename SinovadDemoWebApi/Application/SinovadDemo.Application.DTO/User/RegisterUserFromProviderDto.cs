using SinovadDemo.Domain.Enums;

namespace SinovadDemo.Application.DTO.User
{
    public class RegisterUserFromProviderDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public LinkedAccountProvider LinkedAccountProviderCatalogDetailId { get; set; } 
        public string AccessToken { get; set; }
    }
}
