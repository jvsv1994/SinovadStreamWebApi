using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace SinovadDemo.Application.DTO
{
    public class VideoProfileDto
    {
        public int VideoId { get; set; }
        public int ProfileId { get; set; }
        public double DurationTime { get; set; }
        public double CurrentTime { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
