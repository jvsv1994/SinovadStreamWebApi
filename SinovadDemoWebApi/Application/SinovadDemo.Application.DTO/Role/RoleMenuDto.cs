namespace SinovadDemo.Application.DTO.Role
{
    public class RoleMenuDto
    {
        public int MenuId { get; set; }
        public string MenuTitle { get; set; }
        public bool Enabled { get; set; }
        public bool AllowRead { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }

    }
}
