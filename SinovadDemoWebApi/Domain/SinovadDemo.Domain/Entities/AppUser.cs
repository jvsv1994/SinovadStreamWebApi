using Microsoft.AspNetCore.Identity;

namespace SinovadDemo.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<AccountServer> AccountServers { get; set; } = new List<AccountServer>();
        public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();
        public DateTime? Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }

    }
}
