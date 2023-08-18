﻿using SinovadDemo.Domain.Enums;

namespace SinovadDemo.Application.DTO
{
    public class AuthenticateLinkedAccountRequestDto
    {
        public string AccessToken { get; set; }
        public CatalogEnum LinkedAccountTypeCatalogId { get; set; }
        public LinkedAccountType LinkedAccountTypeCatalogDetailId { get; set; }

    }
}
