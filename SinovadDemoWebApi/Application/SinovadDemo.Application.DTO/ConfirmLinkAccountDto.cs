﻿using SinovadDemo.Domain.Enums;

namespace SinovadDemo.Application.DTO
{
    public class ConfirmLinkAccountDto
    {
        public string Email { get; set; }   
        public string AccessToken { get; set; } 
        public int UserId { get; set;}
        public LinkedAccountType LinkedAccountType  { get; set; }
        public string? Password { get; set; }

    }
}
