using Generic.Core.Models;
using SinovadDemo.Application.DTO;
using SinovadDemo.Domain.Entities;

namespace Pacagroup.Ecommerce.Application.UseCases.Common.Mappings
{
    public class MappingsProfile : AutoMapper.Profile
    {
        public MappingsProfile()
        {
            CreateMap<Catalog, CatalogDto>().ReverseMap();
            CreateMap<CatalogDetail, CatalogDetailDto>().ReverseMap();
            CreateMap<Season, SeasonDto>().ReverseMap();
            CreateMap<Episode, EpisodeDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Menu, MenuDto>().ReverseMap();
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<MovieGenre, MovieGenreDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<TvSerie, TvSerieDto>().ReverseMap();
            CreateMap<TvSerieGenre, TvSerieGenreDto>().ReverseMap();
            CreateMap<MediaServer, MediaServerDto>().ReverseMap();
            CreateMap<RegisterUserDto,User>();
            CreateMap<User, UserDto>().ForMember(x => x.IsPasswordSetted, y => y.MapFrom(y => y.PasswordHash!=null)).ReverseMap();
            CreateMap<Profile, ProfileDto>().ReverseMap();
            CreateMap<LinkedAccount, LinkedAccountDto>().ReverseMap();
        }
    }
}
