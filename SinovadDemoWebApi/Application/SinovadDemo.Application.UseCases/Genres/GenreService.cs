using AutoMapper;
using SinovadDemo.Application.DTO.Genre;
using SinovadDemo.Application.Interface.Infrastructure;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.Genres
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ITmdbService _tmdbService;

        private readonly AutoMapper.IMapper _mapper;

        private readonly IAppLogger<GenreService> _logger;

        public GenreService(IUnitOfWork unitOfWork, ITmdbService tmdbService, IMapper mapper, IAppLogger<GenreService> logger)
        {
            _unitOfWork = unitOfWork;
            _tmdbService = tmdbService;
            _mapper = mapper;
            _logger = logger;
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
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<ResponsePagination<List<GenreDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<GenreDto>>();
            try
            {
                var result = await _unitOfWork.Genres.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
                response.Data = _mapper.Map<List<GenreDto>>(result.Items);
                response.PageNumber = page;
                response.TotalPages = result.Pages;
                response.TotalCount = result.Total;
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
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
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }


        public async Task<Response<GenreDto>> CreateAsync(GenreCreationDto genreCreationDto)
        {
            var response = new Response<GenreDto>();
            try
            {
                var genre = _mapper.Map<Genre>(genreCreationDto);
                await _unitOfWork.Genres.AddAsync(genre);
                await _unitOfWork.SaveAsync();
                response.Data = _mapper.Map<GenreDto>(genre);
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> CreateListAsync(List<GenreCreationDto> list)
        {
            var response = new Response<object>();
            try
            {
                var listEntities = _mapper.Map<List<Genre>>(list);
                await _unitOfWork.Genres.AddListAsync(listEntities);
                await _unitOfWork.SaveAsync();
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> UpdateAsync(int genreId,GenreCreationDto genreCreationDto)
        {
            var response = new Response<object>();
            try
            {
                var genre = await _unitOfWork.Genres.GetAsync(genreId);
                genre = _mapper.Map(genreCreationDto, genre);
                _unitOfWork.Genres.Update(genre);
                await _unitOfWork.SaveAsync();
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex){
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> DeleteAsync(int id)
        {
            var response = new Response<object>();
            try
            {
                _unitOfWork.Genres.Delete(id);
                await _unitOfWork.SaveAsync();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> DeleteListAsync(string ids)
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
                await _unitOfWork.SaveAsync();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<bool> CheckExistAsync(int id)
        {
            return await _unitOfWork.Genres.CheckExist(x => x.Id == id);
        }

    }
}
