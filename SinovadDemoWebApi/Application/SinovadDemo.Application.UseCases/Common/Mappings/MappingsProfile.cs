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

            CreateMap<MovieCreationDto, Movie>().ForMember(movie=>movie.MovieGenres,options=>options.MapFrom(MapMovieGenres));
            CreateMap<Movie, MovieDto>();
            CreateMap<Movie, MovieWithGenresDto>().ForMember(movieDto=>movieDto.MovieGenres,options=>options.MapFrom(MapMovieGenresDto));
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
    }
}
