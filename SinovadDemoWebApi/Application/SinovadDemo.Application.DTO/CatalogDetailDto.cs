using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace SinovadDemo.Application.DTO
{
    public class CatalogDetailDto
    {
        public int CatalogId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string TextValue { get; set; }
        public int? NumberValue { get; set; }
    }
}
