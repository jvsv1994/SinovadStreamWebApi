using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Infrastructure;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.Genres
{
    public class GenreService : IGenreService
    {
        private IUnitOfWork _unitOfWork;

        private SharedService _sharedService;

        private readonly ITmdbService _tmdbService;

        private readonly AutoMapper.IMapper _mapper;

        public GenreService(IUnitOfWork unitOfWork,ITmdbService tmdbService, SharedService sharedService,AutoMapper.IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _sharedService = sharedService;
            _tmdbService = tmdbService;
            _mapper = mapper;
        }

        public async Task<Response<List<GenreDto>>> GetAllAsync()
        {
            var response = new Response<List<GenreDto>>();
            try
            {
                var result = await _unitOfWork.Genres.GetAllAsync();
                response.Data = _mapper.Map<List<GenreDto>>(result);
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<ResponsePagination<List<GenreDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<GenreDto>>();
            try
            {
                var result = await _unitOfWork.Genres.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
                response.Data = _mapper.Map<List<GenreDto>>(result);
                response.PageNumber = page;
                response.TotalPages = result.Pages;
                response.TotalCount = result.Total;
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<GenreDto>> GetAsync(int id)
        {
            var response = new Response<GenreDto>();
            try
            {
                var result = await _unitOfWork.Genres.GetAsync(id);
                response.Data = _mapper.Map<GenreDto>(result);
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }


        public Response<object> Create(GenreDto dto)
        {
            var response = new Response<object>();
            try
            {
                var entity = _mapper.Map<Genre>(dto);
                _unitOfWork.Genres.Add(entity);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> CreateList(List<GenreDto> list)
        {
            var response = new Response<object>();
            try
            {
                var listEntities = _mapper.Map<List<Genre>>(list);
                _unitOfWork.Genres.AddList(listEntities);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> Update(GenreDto dto)
        {
            var response = new Response<object>();
            try
            {
                var entity = _mapper.Map<Genre>(dto);
                _unitOfWork.Genres.Update(entity);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> Delete(int id)
        {
            var response = new Response<object>();
            try
            {
                _unitOfWork.Genres.Delete(id);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> DeleteList(string ids)
        {
            var response = new Response<object>();
            try
            {
                List<int> listIds = new List<int>();
                if (!string.IsNullOrEmpty(ids))
                {
                    listIds = ids.Split(",").Select(x => Convert.ToInt32(x)).ToList();
                }
                _unitOfWork.Genres.DeleteByExpression(x => listIds.Contains(x.Id));
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> CheckAndRegisterGenres()
        {
            var response = new Response<object>();
            try
            {
                List<GenreDto> listGenresDto = _tmdbService.GetListGenres();
                List<int> listIdsGenresDto = listGenresDto.Select(it => (int)it.TmdbId).ToList();
                List<Genre> genresFinded=_unitOfWork.Genres.GetAllByExpression(it=> it.TmdbId!=null && listIdsGenresDto.Contains((int)it.TmdbId)).ToList();
                if(genresFinded.Count==0)
                {
                    var listGenres = _mapper.Map<List<Genre>>(listGenresDto);
                    _unitOfWork.Genres.AddList(listGenres);
                    _unitOfWork.Save();
                }
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

    }
}
