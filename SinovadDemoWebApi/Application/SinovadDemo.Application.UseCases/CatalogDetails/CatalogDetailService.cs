using AutoMapper;
using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using SinovadDemo.Application.DTO.CatalogDetail;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.CatalogDetails
{
    public class CatalogDetailService : ICatalogDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<CatalogDetailService> _logger;

        private readonly IMapper _mapper;

        public CatalogDetailService(IUnitOfWork unitOfWork, ILogger<CatalogDetailService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> CheckIfExistsAsync(int catalogId, int catalogDetailId)
        {
           return await _unitOfWork.CatalogDetails.CheckIfExistAsync(catalogDetail=> catalogDetail.CatalogId==catalogId && catalogDetail.Id==catalogDetailId);
        }

        public async Task<Response<CatalogDetailDto>> CreateAsync(int catalogId, CatalogDetailCreationDto catalogDetailCreationDto)
        {
            var response = new Response<CatalogDetailDto>();
            try
            {
                var catalogDetail = _mapper.Map<CatalogDetail>(catalogDetailCreationDto);
                catalogDetail.CatalogId = catalogId;
                catalogDetail.Id = await _unitOfWork.CatalogDetails.CountByExpressionAsync(catalogDetail=>catalogDetail.CatalogId==catalogId) + 1;
                catalogDetail = await _unitOfWork.CatalogDetails.AddAsync(catalogDetail);
                await _unitOfWork.SaveAsync();
                response.Data = _mapper.Map<CatalogDetailDto>(catalogDetail);
                response.IsSuccess = true;
            }catch(Exception exception)
            {
                response.Message= exception.Message;
                _logger.LogError(exception.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> DeleteAsync(int catalogId, int catalogDetailId)
        {
            var response = new Response<object>();
            try
            {
                _unitOfWork.CatalogDetails.DeleteByExpression(catalogDetail=>catalogDetail.CatalogId==catalogId && catalogDetail.Id==catalogDetailId);  
                await _unitOfWork.SaveAsync();
                response.IsSuccess= true;
            }catch(Exception exception) {
                response.Message = exception.Message;
                _logger.LogError(exception.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> DeleteListAsync(int catalogId, string ids)
        {
            var response = new Response<object>();
            try
            {
                var listCatalogDetailIds=ids.Split(',').Select(id=>int.Parse(id)).ToList();
                _unitOfWork.CatalogDetails.DeleteByExpression(catalogDetail => catalogDetail.CatalogId == catalogId && listCatalogDetailIds.Contains(catalogDetail.Id));
                await _unitOfWork.SaveAsync();
                response.IsSuccess = true;
            }catch (Exception exception)
            {
                response.Message = exception.Message;
                _logger.LogError(exception.StackTrace);
            }
            return response;
        }

        public async Task<ResponsePagination<List<CatalogDetailDto>>> GetAllWithPaginationAsync(int catalogId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<CatalogDetailDto>>();
            try
            {
                var result= await _unitOfWork.CatalogDetails.GetAllWithPaginationByExpressionAsync(page,take,sortBy,sortDirection,searchText,searchBy, catalogDetail => catalogDetail.CatalogId == catalogId);
                response.Data = _mapper.Map<List<CatalogDetailDto>>(result.Items.ToList());
                response.PageNumber = result.Page;
                response.TotalPages = result.Pages;
                response.TotalCount = result.Total;
                response.IsSuccess = true;
            }catch (Exception exception){
                response.Message = exception.Message;
                _logger.LogError(exception.StackTrace);
            }
            return response;
        }

        public async Task<Response<List<CatalogDetailDto>>> GetAllAsync(int catalogId)
        {
            var response = new Response<List<CatalogDetailDto>>();
            try
            {
                var result = await _unitOfWork.CatalogDetails.GetAllByExpressionAsync(catalogDetail => catalogDetail.CatalogId == catalogId);
                response.Data = _mapper.Map<List<CatalogDetailDto>>(result);
                response.IsSuccess = true;
            }
            catch (Exception exception)
            {
                response.Message = exception.Message;
                _logger.LogError(exception.StackTrace);
            }
            return response;
        }

        public async Task<Response<CatalogDetailDto>> GetAsync(int catalogId, int catalogDetailId)
        {
            var response = new Response<CatalogDetailDto>();
            try
            {
                var result = await _unitOfWork.CatalogDetails.GetByExpressionAsync(catalogDetail => catalogDetail.Id==catalogDetailId && catalogDetail.CatalogId == catalogId, catalogDetail => catalogDetail.Catalog);
                response.Data = _mapper.Map<CatalogDetailDto>(result);
                response.IsSuccess = true;
            }catch (Exception exception)
            {
                response.Message = exception.Message;
                _logger.LogError(exception.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> UpdateAsync(int catalogId, int catalogDetailId, CatalogDetailCreationDto catalogDetailCreationDto)
        {
            var response = new Response<object>();
            try
            {
                var catalogDetail = await _unitOfWork.CatalogDetails.GetByExpressionAsync(catalogDetail => catalogDetail.Id == catalogDetailId && catalogDetail.CatalogId == catalogId);
                catalogDetail = _mapper.Map(catalogDetailCreationDto, catalogDetail);
                _unitOfWork.CatalogDetails.Update(catalogDetail);
                await _unitOfWork.SaveAsync();
                response.IsSuccess = true;
            }catch (Exception exception)
            {
                response.Message = exception.Message;
                _logger.LogError(exception.StackTrace);
            }
            return response;
        }
    }
}
