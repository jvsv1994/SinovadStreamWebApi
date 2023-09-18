using Microsoft.Extensions.Options;
using SinovadDemo.Application.Configuration;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Infrastructure;

namespace SinovadDemo.Infrastructure.Imdb
{
    public class ImdbService:IImdbService
    {

        private readonly IMDbApiLib.ApiLib _imdbApiLib;

        public ImdbService(IOptions<MyConfig> options)
        {
            _imdbApiLib = new IMDbApiLib.ApiLib(options.Value.IMDbApiKey);
        }

        public MovieDto SearchMovie(string movieName, string year)
        {
            IMDbApiLib.Models.TitleData titleData = null;
            IMDbApiLib.Models.SearchData result = _imdbApiLib.SearchMovieAsync(movieName + " " + year).Result;
            if (result != null && result.Results != null && result.Results.Count > 0)
            {
                IMDbApiLib.Models.SearchResult search = result.Results[0];
                string imdbID = search.Id;
                titleData = _imdbApiLib.TitleAsync(imdbID, IMDbApiLib.Models.Language.es).Result;
            }

            MovieDto movieDto = null;
            if (titleData!= null)
            {
                movieDto = new MovieDto();
                movieDto.Adult = false;
                movieDto.OriginalLanguage = titleData.Languages;
                movieDto.OriginalTitle = titleData.OriginalTitle;
                movieDto.Overview = titleData.PlotLocal;
                movieDto.PosterPath = titleData.Image;
                movieDto.ReleaseDate = DateTime.Parse(titleData.ReleaseDate);
                movieDto.Title = titleData.Title;
            }
            return movieDto;
        }

    }
}
