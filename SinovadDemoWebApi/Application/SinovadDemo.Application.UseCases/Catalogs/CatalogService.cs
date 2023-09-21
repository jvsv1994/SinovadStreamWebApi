using AutoMapper;
using SinovadDemo.Application.DTO.Catalog;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.Catalogs
{
    public class CatalogService : ICatalogService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly AutoMapper.IMapper _mapper;

        private readonly IAppLogger<CatalogService> _logger;

        public CatalogService(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<CatalogService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<CatalogDto>> GetAsync(int id)
        {
            var response = new Response<CatalogDto>();
            try
            {
                var result = await _unitOfWork.Catalogs.GetAsync(id);
                response.Data = _mapper.Map<CatalogDto>(result);
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
        public async Task<ResponsePagination<List<CatalogDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<CatalogDto>>();
            try
            {
                var result = await _unitOfWork.Catalogs.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
                response.Data = _mapper.Map<List<CatalogDto>>(result.Items);
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

        public Response<object> Create(CatalogDto catalogDto)
        {
            var response = new Response<object>();
            try
            {
                var catalog = _mapper.Map<Catalog>(catalogDto);
                _unitOfWork.Catalogs.Add(catalog);
                _unitOfWork.Save();
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

        public Response<object> Update(CatalogDto catalogDto)
        {
            var response = new Response<object>();
            try
            {
                var catalog = _mapper.Map<Catalog>(catalogDto);
                _unitOfWork.Catalogs.Update(catalog);
                _unitOfWork.Save();
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

        public Response<object> Delete(int id)
        {
            var response = new Response<object>();
            try
            {
                _unitOfWork.Catalogs.Delete(id);
                _unitOfWork.Save();
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
                _unitOfWork.Catalogs.DeleteByExpression(x => listIds.Contains(x.Id));
                _unitOfWork.Save();
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

        public async Task<Response<CatalogDetailDto>> GetCatalogDetailAsync(int catalogId, int catalogDetailId)
        {
            var response = new Response<CatalogDetailDto>();
            try
            {
                var result = await _unitOfWork.CatalogDetails.GetByExpressionAsync(x => x.CatalogId == catalogId && x.Id == catalogDetailId);
                response.Data = _mapper.Map<CatalogDetailDto>(result);
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

        public async Task<Response<List<CatalogDetailDto>>> GetDetailsByCatalogAsync(int catalogId)
        {
            var response = new Response<List<CatalogDetailDto>>();
            try
            {
                var result = await _unitOfWork.CatalogDetails.GetAllByExpressionAsync(x => x.CatalogId == catalogId);
                response.Data = _mapper.Map<List<CatalogDetailDto>>(result);
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

        public async Task<ResponsePagination<List<CatalogDetailDto>>> GetAllCatalogDetailsWithPaginationByCatalogIdsAsync(string catalogIds, int page, int take)
        {
            var response = new ResponsePagination<List<CatalogDetailDto>>();
            try
            {
                List<int> listIds = new List<int>();
                if (!string.IsNullOrEmpty(catalogIds))
                {
                    listIds = catalogIds.Split(",").Select(x => Convert.ToInt32(x)).ToList();
                }
                var result = await _unitOfWork.CatalogDetails.GetAllWithPaginationByExpressionAsync(page, take, "Id", "desc","","", x => listIds.Contains(x.CatalogId));
                response.Data = _mapper.Map<List<CatalogDetailDto>>(result.Items);
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

        public async Task<Response<List<CatalogDetailDto>>> GetAllCatalogDetailsByCatalogIds(string catalogIds)
        {
            var response = new Response<List<CatalogDetailDto>>();
            try
            {
                List<int> listIds = new List<int>();
                if (!string.IsNullOrEmpty(catalogIds))
                {
                    listIds = catalogIds.Split(",").Select(x => Convert.ToInt32(x)).ToList();
                }
                var result = await _unitOfWork.CatalogDetails.GetAllByExpressionAsync(x => listIds.Contains(x.CatalogId));
                response.Data = _mapper.Map<List<CatalogDetailDto>>(result);
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


    }
}
