using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinovadDemo.Application.DTO
{
    public class UpdateStorageVideosDto
    {
        public List<AccountStorageDto> ListAccountStorages { get; set; }
        public string LogIdentifier { get; set; }

    }
}
