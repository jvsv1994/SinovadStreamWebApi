﻿namespace SinovadDemo.Application.DTO.User
{
    public partial class UserDto
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public bool IsPasswordSetted { get; set; }

    }
}
