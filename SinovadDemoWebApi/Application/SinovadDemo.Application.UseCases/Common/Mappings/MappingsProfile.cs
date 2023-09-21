using Generic.Core.Models;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.DTO.Authenticate;
using SinovadDemo.Application.DTO.Catalog;
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

            CreateMap<Catalog, CatalogDto>().ReverseMap();
            CreateMap<CatalogDetail, CatalogDetailDto>().ReverseMap();
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
    }
}
