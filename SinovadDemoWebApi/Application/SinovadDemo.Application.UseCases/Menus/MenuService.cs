using Generic.Core.Models;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.Users
{
    public class MenuService : IMenuService
    {
        private IUnitOfWork _unitOfWork;

        private readonly IAppLogger<UserService> _logger;

        private readonly AutoMapper.IMapper _mapper;

        public MenuService(IUnitOfWork unitOfWork, IAppLogger<UserService> logger, AutoMapper.IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
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

        public Response<object> Create(MenuDto dto)
        {
            var response = new Response<object>();
            try
            {
                var entity = _mapper.Map<Menu>(dto);
                _unitOfWork.Menus.Add(entity);
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

        public Response<object> Update(MenuDto dto)
        {
            var response = new Response<object>();
            try
            {
                var entity = _mapper.Map<Menu>(dto);
                _unitOfWork.Menus.Update(entity);
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

        public async Task<Response<List<MenuDto>>> GetListMenusByUser(int userId)
        {
            var response = new Response<List<MenuDto>>();
            try
            {
                var list= await BuildListMenusByUser(userId);
                response.Data = list;
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
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
