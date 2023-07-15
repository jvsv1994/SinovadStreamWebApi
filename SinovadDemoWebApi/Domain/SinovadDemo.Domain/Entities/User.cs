using Generic.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinovadDemo.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CountryCode { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<MediaServer> MediaServers { get; set; } = new List<MediaServer>();
        public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();
        public DateTime? Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        [NotMapped]
        public virtual ICollection<String> RoleNames { get; set; }


    }
}
