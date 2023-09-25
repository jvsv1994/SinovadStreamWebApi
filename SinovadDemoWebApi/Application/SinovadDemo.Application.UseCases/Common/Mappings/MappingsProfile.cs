using Generic.Core.Models;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.DTO.Authenticate;
using SinovadDemo.Application.DTO.Catalog;
using SinovadDemo.Application.DTO.CatalogDetail;
using SinovadDemo.Application.DTO.Episode;
using SinovadDemo.Application.DTO.Genre;
using SinovadDemo.Application.DTO.MediaServer;
using SinovadDemo.Application.DTO.Menu;
using SinovadDemo.Application.DTO.Movie;
using SinovadDemo.Application.DTO.Profile;
using SinovadDemo.Application.DTO.Role;
using SinovadDemo.Application.DTO.Season;
using SinovadDemo.Application.DTO.SignUp;
using SinovadDemo.Application.DTO.TvSerie;
using SinovadDemo.Application.DTO.User;
using SinovadDemo.Domain.Entities;

namespace Pacagroup.Ecommerce.Application.UseCases.Common.Mappings
{
    public class MappingsProfile : AutoMapper.Profile
    {
        public MappingsProfile()
        {
            CreateMap<RegisterUserDto, User>();
            CreateMap<RegisterUserFromProviderDto, User>();
            CreateMap<User, UserDto>().ForMember(x => x.IsPasswordSetted, y => y.MapFrom(y => y.PasswordHash != null)).ReverseMap();
            CreateMap<User, UserWithRolesDto>().ForMember(uwrdto => uwrdto.UserRoles, options => options.MapFrom(MapRolesFromUser));
            CreateMap<UserRoleDto, UserRole>();

            CreateMap<CatalogCreationDto, Catalog>();
            CreateMap<Catalog, CatalogDto>().ReverseMap();

            CreateMap<CatalogDetailCreationDto, CatalogDetail>();
            CreateMap<CatalogDetail, CatalogDetailDto>().ReverseMap();

            CreateMap<MenuCreationDto, Menu>();
            CreateMap<Menu, MenuDto>().ReverseMap();

            CreateMap<ProfileCreationDto, Profile>();
            CreateMap<Profile, ProfileDto>().ReverseMap();

            CreateMap<MovieCreationDto, Movie>().ForMember(movie=>movie.MovieGenres,options=>options.MapFrom(MapMovieGenres));
            CreateMap<Movie, MovieDto>();
            CreateMap<Movie, MovieWithGenresDto>().ForMember(movieDto=>movieDto.MovieGenres,options=>options.MapFrom(MapMovieGenresDto));
            CreateMap<MovieGenre, MovieGenreDto>().ReverseMap();

            CreateMap<TvSerieCreationDto, TvSerie>().ForMember(tvSerie => tvSerie.TvSerieGenres, options => options.MapFrom(MapTvSerieGenres));
            CreateMap<TvSerie, TvSerieDto>();
            CreateMap<TvSerie, TvSerieWithGenresDto>().ForMember(tvSerieDto => tvSerieDto.TvSerieGenres, options => options.MapFrom(MapTvSerieGenresDto));
            CreateMap<TvSerieGenre, TvSerieGenreDto>().ReverseMap();

            CreateMap<SeasonCreationDto, Season>();
            CreateMap<Season, SeasonDto>().ReverseMap();

            CreateMap<EpisodeCreationDto, Episode>();
            CreateMap<Episode, EpisodeDto>().ReverseMap();

            CreateMap<GenreCreationDto, Genre>();
            CreateMap<Genre, GenreDto>().ReverseMap();

            CreateMap<RoleCreationDto, Role>();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Role, RoleWithMenusDto>().ForMember(rwmdto => rwmdto.RoleMenus, options => options.MapFrom(MapMenusFromRole));
            CreateMap<RoleMenuDto, RoleMenu>();

            CreateMap<MediaServerCreationDto, MediaServer>();
            CreateMap<MediaServer, MediaServerDto>().ReverseMap();

            CreateMap<LinkedAccount, LinkedAccountDto>().ReverseMap();
        }

        private List<MovieGenre> MapMovieGenres(MovieCreationDto movieCreationDto, Movie movie)
        {
            var result= new List<MovieGenre>();

            if (movieCreationDto.GenresIds == null) return result;

            foreach (var genreId in movieCreationDto.GenresIds)
            {
                result.Add(new MovieGenre() { GenreId = genreId });
            }
            return result;
        }

        private List<MovieGenreDto> MapMovieGenresDto(Movie movie, MovieDto movieDto)
        {
            var result = new List<MovieGenreDto>();

            if (movie.MovieGenres == null) return result;

            foreach (var movieGenre in movie.MovieGenres)
            {
                result.Add(new MovieGenreDto() { GenreId = movieGenre.GenreId,MovieId= movieGenre.MovieId,GenreName= movieGenre.Genre.Name });
            }
            return result;
        }

        private List<TvSerieGenre> MapTvSerieGenres(TvSerieCreationDto tvSerieCreationDto, TvSerie tvSerie)
        {
            var result = new List<TvSerieGenre>();

            if (tvSerieCreationDto.GenresIds == null) return result;

            foreach (var genreId in tvSerieCreationDto.GenresIds)
            {
                result.Add(new TvSerieGenre() { GenreId = genreId });
            }
            return result;
        }

        private List<TvSerieGenreDto> MapTvSerieGenresDto(TvSerie tvSerie, TvSerieWithGenresDto tvSerieDto)
        {
            var result = new List<TvSerieGenreDto>();

            if (tvSerie.TvSerieGenres == null) return result;

            foreach (var tvSerieGenre in tvSerie.TvSerieGenres)
            {
                result.Add(new TvSerieGenreDto() { GenreId = tvSerieGenre.GenreId, TvSerieId = tvSerieGenre.TvSerieId, GenreName = tvSerieGenre.Genre.Name });
            }
            return result;
        }

        private List<UserRoleDto> MapRolesFromUser(User user, UserWithRolesDto userWithRolesDto)
        {
            var result = new List<UserRoleDto>();

            if (user.UserRoles == null) return result;

            foreach (var userRole in user.UserRoles)
            {
                result.Add(new UserRoleDto() { RoleId = userRole.Role.Id, RoleName = userRole.Role.Name, Enabled = userRole.Enabled });
            }
            return result;
        }

        private List<RoleMenuDto> MapMenusFromRole(Role role, RoleWithMenusDto roleWithMenusDto)
        {
            var result = new List<RoleMenuDto>();

            if (role.RoleMenus == null) return result;

            foreach (var roleMenu in role.RoleMenus)
            {
                result.Add(new RoleMenuDto() { MenuId = roleMenu.Menu.Id, MenuTitle = roleMenu.Menu.Title, Enabled = roleMenu.Enabled 
                    ,AllowCreate= roleMenu.AllowCreate, AllowUpdate = roleMenu.AllowUpdate,AllowRead= roleMenu.AllowRead,AllowDelete = roleMenu.AllowDelete
                });
            }
            return result;
        }


        


    }
}
