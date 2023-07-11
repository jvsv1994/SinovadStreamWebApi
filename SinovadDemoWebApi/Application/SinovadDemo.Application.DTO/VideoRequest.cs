using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinovadDemo.Application.DTO
{
    public class VideoRequest
    {
        public int accountStorageId { get; set; }
        public int accountStorageTypeId { get; set; }
        public string paths { get; set; }
        public string logIdentifier { get; set; }

    }
}
