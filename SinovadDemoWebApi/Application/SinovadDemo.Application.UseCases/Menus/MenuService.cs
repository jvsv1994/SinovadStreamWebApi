using Generic.Core.Models;
using SinovadDemo.Application.DTO.Menu;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.Users
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IAppLogger<MenuService> _logger;

        private readonly AutoMapper.IMapper _mapper;

        public MenuService(IUnitOfWork unitOfWork, IAppLogger<MenuService> logger, AutoMapper.IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Response<MenuDto>> GetAsync(int menuId)
        {
            var response = new Response<MenuDto>();
            try
            {
                var result = await _unitOfWork.Menus.GetAsync(menuId);
                response.Data = _mapper.Map<MenuDto>(result);
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

        public async Task<Response<List<MenuDto>>> GetAllAsync()
        {
            var response = new Response<List<MenuDto>>();
            try
            {
                var result = await _unitOfWork.Menus.GetAllAsync();
                response.Data = _mapper.Map<List<MenuDto>>(result);
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

        public async Task<ResponsePagination<List<MenuDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<MenuDto>>();
            try
            {
                var result = await _unitOfWork.Menus.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
                response.Data = _mapper.Map<List<MenuDto>>(result.Items);
                response.PageNumber = page;
                response.TotalPages = result.Pages;
                response.TotalCount = result.Total;
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<MenuDto>> CreateAsync(MenuCreationDto menuCreationDto)
        {
            var response = new Response<MenuDto>();
            try
            {
                var menu = _mapper.Map<Menu>(menuCreationDto);
                menu= await _unitOfWork.Menus.AddAsync(menu);
                await _unitOfWork.SaveAsync();
                response.Data = _mapper.Map<MenuDto>(menu);
                response.IsSuccess = true;
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> UpdateAsync(int menuId,MenuCreationDto menuCreationDto)
        {
            var response = new Response<object>();
            try
            {
                var menu = await _unitOfWork.Menus.GetAsync(menuId);
                menu = _mapper.Map(menuCreationDto, menu);
                _unitOfWork.Menus.Update(menu);
                await _unitOfWork.SaveAsync();
                response.IsSuccess = true;
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
                _unitOfWork.Menus.Delete(id);
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
                _unitOfWork.Menus.DeleteByExpression(x => listIds.Contains(x.Id));
                await _unitOfWork.SaveAsync();
                response.IsSuccess = true;
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<List<MenuDto>>> GetListMenusByUserAsync(int userId)
        {
            var response = new Response<List<MenuDto>>();
            try
            {
                var list= await BuildListMenusByUser(userId);
                response.Data = list;
                response.IsSuccess = true;
            }catch (Exception ex){
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<bool> CheckIfExistsAsync(int menuId)
        {
            return await _unitOfWork.Menus.CheckIfExistAsync(menu=>menu.Id==menuId);
        }

        private async Task<List<MenuDto>> BuildListMenusByUser(int userId)
        {
            var result = await _unitOfWork.Menus.GetListMenusByUser(userId);
            var listMenus = _mapper.Map<List<MenuDto>>(result);
            var mainMenus = listMenus.Where(m => m.ParentId == 0 && m.Enabled == true).OrderBy(m => m.SortOrder).ToList();
            mainMenus.ForEach(m => m.ChildMenus = BuildMenuChilds(m.Id, listMenus));
            return mainMenus;
        }

        private List<MenuDto> BuildMenuChilds(int parentId, List<MenuDto> originalList)
        {
            var listMenus = originalList.Where(m => m.ParentId == parentId && m.Enabled == true).OrderBy(m => m.SortOrder).ToList();
            listMenus.ForEach(m => m.ChildMenus = BuildMenuChilds(m.Id, originalList));
            return listMenus;
        }

    }
}
