using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace SinovadDemo.Application.DTO
{
    public class ItemsGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ItemDto> ListItems { get; set; }

    }
}
