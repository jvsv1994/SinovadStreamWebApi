using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace SinovadDemo.Application.DTO
{
    public class TranscodeSettingDto
    {
        public int Id { get; set; }
        public int AccountServerId { get; set; }
        public int TransmissionMethodCatalogId { get; set; }
        public int TransmissionMethodCatalogDetailId { get; set; }
        public int PresetCatalogId { get; set; }
        public int PresetCatalogDetailId { get; set; }
        public string DirectoryPhysicalPath { get; set; }
        public int ConstantRateFactor { get; set; }
    }
}
