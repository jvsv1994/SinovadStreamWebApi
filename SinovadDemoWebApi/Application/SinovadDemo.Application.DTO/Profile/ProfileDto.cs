namespace SinovadDemo.Application.DTO.Profile
{
    public class ProfileDto
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public bool Main { get; set; }
        public int? Pincode { get; set; }
        public string AvatarPath { get; set; }
    }
}
