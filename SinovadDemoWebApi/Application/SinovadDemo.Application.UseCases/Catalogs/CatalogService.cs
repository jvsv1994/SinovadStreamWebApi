using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;

namespace SinovadDemo.Application.UseCases.Catalogs
{
    public class CatalogService : ICatalogService
    {
        private IUnitOfWork _unitOfWork;

        private readonly SharedService _sharedService;

        public CatalogService(IUnitOfWork unitOfWork, SharedService sharedService)
        {
            _unitOfWork = unitOfWork;
            _sharedService = sharedService;
        }
        public async Task<Response<CatalogDto>> GetAsync(int id)
        {
            var response = new Response<CatalogDto>();
            try
            {
                var result = await _unitOfWork.Catalogs.GetAsync(id);
                response.Data = result.MapTo<CatalogDto>();
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
        public async Task<ResponsePagination<List<CatalogDto>>> GetAllWithPaginationAsync(int page, int take)
        {
            var response = new ResponsePagination<List<CatalogDto>>();
            try
            {
                var result = await _unitOfWork.Catalogs.GetAllWithPaginationAsync(page, take, "Id", false);
                response.Data = result.Items.MapTo<List<CatalogDto>>();
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

        public Response<object> Create(CatalogDto catalogDto)
        {
            var response = new Response<object>();
            try
            {
                var catalog = catalogDto.MapTo<Catalog>();
                _unitOfWork.Catalogs.Add(catalog);
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

        public Response<object> Update(CatalogDto catalogDto)
        {
            var response = new Response<object>();
            try
            {
                var catalog = catalogDto.MapTo<Catalog>();
                _unitOfWork.Catalogs.Update(catalog);
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
                _unitOfWork.Catalogs.Delete(id);
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
                _unitOfWork.Catalogs.DeleteByExpression(x => listIds.Contains(x.Id));
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

        public async Task<Response<CatalogDetailDto>> GetCatalogDetailAsync(int catalogId, int catalogDetailId)
        {
            var response = new Response<CatalogDetailDto>();
            try
            {
                var result = await _unitOfWork.CatalogDetails.GetByExpressionAsync(x => x.CatalogId == catalogId && x.Id == catalogDetailId);
                response.Data = result.MapTo<CatalogDetailDto>();
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

        public async Task<Response<List<CatalogDetailDto>>> GetDetailsByCatalogAsync(int catalogId)
        {
            var response = new Response<List<CatalogDetailDto>>();
            try
            {
                var result = await _unitOfWork.CatalogDetails.GetAllByExpressionAsync(x => x.CatalogId == catalogId);
                response.Data = result.MapTo<List<CatalogDetailDto>>();
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
                var result = await _unitOfWork.CatalogDetails.GetAllWithPaginationByExpressionAsync(page, take, "Id", false, x => listIds.Contains(x.CatalogId));
                response.Data = result.Items.MapTo<List<CatalogDetailDto>>();
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

    }
}
