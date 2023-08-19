using SinovadDemo.Application.DTO;
using SinovadDemo.Domain.Entities;

namespace Pacagroup.Ecommerce.Application.UseCases.Common.Mappings
{
    public class MappingsProfile : AutoMapper.Profile
    {
        public MappingsProfile()
        {
            CreateMap<MediaServer, MediaServerDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Profile, ProfileDto>().ReverseMap();
            CreateMap<LinkedAccount, LinkedAccountDto>().ReverseMap();
        }
    }
}
