﻿using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.Profiles
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly AutoMapper.IMapper _mapper;

        private readonly IAppLogger<ProfileService> _logger;

        public ProfileService(IUnitOfWork unitOfWork, AutoMapper.IMapper mapper, IAppLogger<ProfileService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<ProfileDto>> GetAsync(int id)
        {
            var response = new Response<ProfileDto>();
            try
            {
                var result = await _unitOfWork.Profiles.GetAsync(id);
                response.Data = _mapper.Map<ProfileDto>(result);
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

        public async Task<Response<ProfileDto>> GetByGuidAsync(string guid)
        {
            var response = new Response<ProfileDto>();
            try
            {
                var result = await _unitOfWork.Profiles.GetByExpressionAsync(x => x.Guid.ToString() == guid);
                response.Data = _mapper.Map<ProfileDto>(result);
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<ResponsePagination<List<ProfileDto>>> GetAllWithPaginationByUserAsync(int userId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<ProfileDto>>();
            try
            {
                var result = await _unitOfWork.Profiles.GetAllWithPaginationByExpressionAsync(page, take, sortBy, sortDirection, searchText, searchBy, x => x.UserId == userId);
                response.Data = _mapper.Map<List<ProfileDto>>(result.Items);
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

        public Response<object> Create(ProfileDto profileDto)
        {
            var response = new Response<object>();
            try
            {
                var profile = _mapper.Map<Profile>(profileDto);
                _unitOfWork.Profiles.Add(profile);
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

        public Response<object> CreateList(List<ProfileDto> listProfileDto)
        {
            var response = new Response<object>();
            try
            {
                var profiles = _mapper.Map<List<Profile>>(listProfileDto);
                _unitOfWork.Profiles.AddList(profiles);
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

        public Response<object> Update(ProfileDto profileDto)
        {
            var response = new Response<object>();
            try
            {
                var profile = _mapper.Map<Profile>(profileDto);
                _unitOfWork.Profiles.Update(profile);
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
                _unitOfWork.Profiles.Delete(id);
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
                _unitOfWork.Profiles.DeleteByExpression(x => listIds.Contains(x.Id));
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

    }
}
