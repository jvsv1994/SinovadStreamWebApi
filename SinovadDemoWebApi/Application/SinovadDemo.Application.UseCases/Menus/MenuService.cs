using Generic.Core.Models;
using Microsoft.Extensions.Options;
using SinovadDemo.Application.Configuration;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;
using MediaType = SinovadDemo.Domain.Enums.MediaType;

namespace SinovadDemo.Application.UseCases.Users
{
    public class MenuService : IMenuService
    {
        private IUnitOfWork _unitOfWork;

        private readonly IAppLogger<UserService> _logger;

        private readonly IOptions<MyConfig> _config;

        public MenuService(IUnitOfWork unitOfWork, IAppLogger<UserService> logger, IOptions<MyConfig> config)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _config = config;
        }

        public async Task<Response<List<MenuDto>>> GetAllAsync()
        {
            var response = new Response<List<MenuDto>>();
            try
            {
                var result = await _unitOfWork.Menus.GetAllAsync();
                response.Data = result.MapTo<List<MenuDto>>();
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
                response.Data = result.Items.MapTo<List<MenuDto>>();
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
                var entity = dto.MapTo<Menu>();
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
                var entity = dto.MapTo<Menu>();
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
            var listMenus = result.MapTo<List<MenuDto>>();
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



        public async Task<Response<List<MenuDto>>> GetMediaMenuByUserAsync(int userId)
        {
            var response = new Response<List<MenuDto>>();
            try
            {
                var list = await BuildMediaMenuByUser(userId);
                response.Data = list;
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

        private async Task<List<MenuDto>> BuildMediaMenuByUser(int userId)
        {
            List<MenuDto> listOptions= new List<MenuDto>();
            var home = new MenuDto();
            home.SortOrder = listOptions.Count+1;
            home.Title = "Inicio";
            home.Path = "/home";
            home.IconClass = "fa-house fa-solid";
            listOptions.Add(home);
            var movies = new MenuDto();
            movies.SortOrder = listOptions.Count + 1;
            movies.Title = "Películas";
            movies.Path = "/media/movies";
            movies.IconClass = "fa-film fa-solid";
            listOptions.Add(movies);
            var tvseries = new MenuDto();
            tvseries.SortOrder = listOptions.Count + 1;
            tvseries.Title = "Series";
            tvseries.Path = "/media/tvseries";
            tvseries.IconClass = "fa-tv fa-solid";
            listOptions.Add(tvseries);
            var listLibraries= await _unitOfWork.Storages.GetAllByExpressionAsync(x=>x.MediaServer.User.Id==userId);
            if(listLibraries!=null && listLibraries.Count()>0)
            {
                var listMediaServers = await _unitOfWork.MediaServers.GetAllByExpressionAsync(x => listLibraries.Select(x => x.MediaServerId).Contains(x.Id));
                foreach(var mediaServer in listMediaServers)
                {
                    var ms = new MenuDto();
                    ms.SortOrder = listOptions.Count + 1;
                    ms.Title = mediaServer.FamilyName!=null && mediaServer.FamilyName!="" ? mediaServer.FamilyName:mediaServer.DeviceName;
                    ms.Path = "/media/server/"+mediaServer.Guid;
                    ms.ChildMenus= new List<MenuDto>();
                    var libraries=listLibraries.Where(x => x.MediaServerId == mediaServer.Id);
                    foreach (var library in libraries)
                    {
                        var ml = new MenuDto();
                        ml.SortOrder = ms.ChildMenus.Count + 1;
                        ml.Title = library.Name;
                        ml.Path = "/media/server/" + mediaServer.Guid+"/libraries/"+library.Id;
                        ml.IconClass = library.MediaTypeCatalogDetailId == (int)MediaType.Movie ? "fa-film fa-solid" : "fa-tv fa-solid";
                        ms.ChildMenus.Add(ml);
                    }
                    listOptions.Add(ms);
                }
            }
            return listOptions;
        }

    }
}
