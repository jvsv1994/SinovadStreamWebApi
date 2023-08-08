using SinovadDemo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinovadDemo.Application.DTO
{
    public class VideoRequest
    {
        public int LibraryId { get; set; }
        public MediaType MediaType { get; set; }
        public string Paths { get; set; }
        public string LogIdentifier { get; set; }

    }
}
