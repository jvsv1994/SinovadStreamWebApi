using SinovadDemo.Application.DTO.Profile;
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

        public async Task<Response<List<ProfileDto>>> GetAllAsync(int userId)
        {
            var response = new Response<List<ProfileDto>>();
            try
            {
                var result = await _unitOfWork.Profiles.GetAllByExpressionAsync(x => x.UserId == userId);
                response.Data = _mapper.Map<List<ProfileDto>>(result.ToList());
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<ResponsePagination<List<ProfileDto>>> GetAllWithPaginationAsync(int userId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
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

        public async Task<Response<ProfileDto>> CreateAsync(int userId,ProfileCreationDto profileCreationDto)
        {
            var response = new Response<ProfileDto>();
            try
            {
                var profile = _mapper.Map<Profile>(profileCreationDto);
                profile.UserId=userId;
                await _unitOfWork.Profiles.AddAsync(profile);
                await _unitOfWork.SaveAsync();
                response.Data = _mapper.Map<ProfileDto>(profile);
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> UpdateAsync(int profileId,ProfileCreationDto profileCreationDto)
        {
            var response = new Response<object>();
            try
            {
                var profile = await _unitOfWork.Profiles.GetAsync(profileId);
                profile = _mapper.Map(profileCreationDto, profile);
                _unitOfWork.Profiles.Update(profile);
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

        public async Task<Response<object>> DeleteAsync(int id)
        {
            var response = new Response<object>();
            try
            {
                _unitOfWork.Profiles.Delete(id);
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

        public async Task<bool> CheckIfExistAsync(int id)
        {
           return await _unitOfWork.Profiles.CheckIfExistAsync(profile=>profile.Id==id);
        }
    }
}
