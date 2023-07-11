﻿using System.ComponentModel.DataAnnotations;

namespace SinovadDemo.Application.DTO
{
    public class RecoverPasswordDto
    {
        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddress]
        public string Email { get; set; }
        public string ResetPasswordUrl { get; set; }

    }
}
