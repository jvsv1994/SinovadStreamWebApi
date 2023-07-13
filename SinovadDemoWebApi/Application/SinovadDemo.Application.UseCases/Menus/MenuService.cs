using Microsoft.Extensions.Options;
using SinovadDemo.Application.Configuration;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;

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
          var result= await _unitOfWork.Menus.GetListMenusByUser(userId);
          var listMenus = result.MapTo<List<MenuDto>>();
          var mainMenus = listMenus.Where(m => m.ParentId == 0).ToList();
          mainMenus.ForEach(m => m.ChildMenus = BuildMenuChilds(m.Id, listMenus));
          return mainMenus;
        }

        private List<MenuDto> BuildMenuChilds(int parentId,List<MenuDto> originalList)
        {
           var listMenus=originalList.Where(m => m.ParentId == parentId).ToList();
           listMenus.ForEach(m => m.ChildMenus = BuildMenuChilds(m.Id, originalList));
           return listMenus;
        }

    }
}
