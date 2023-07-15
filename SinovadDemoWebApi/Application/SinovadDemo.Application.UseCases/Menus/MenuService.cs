﻿using Generic.Core.Models;
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

        public async Task<ResponsePagination<List<MenuDto>>> GetAllWithPaginationAsync(int page, int take)
        {
            var response = new ResponsePagination<List<MenuDto>>();
            try
            {
                var result = await _unitOfWork.Menus.GetAllWithPaginationAsync(page, take, "Id", false);
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
          var result= await _unitOfWork.Menus.GetListMenusByUser(userId);
          var listMenus = result.MapTo<List<MenuDto>>();
          var mainMenus = listMenus.Where(m => m.ParentId == 0).OrderBy(m => m.SortOrder).ToList();
          mainMenus.ForEach(m => m.ChildMenus = BuildMenuChilds(m.Id, listMenus));
          return mainMenus;
        }

        private List<MenuDto> BuildMenuChilds(int parentId,List<MenuDto> originalList)
        {
           var listMenus=originalList.Where(m => m.ParentId == parentId).OrderBy(m=>m.SortOrder).ToList();
           listMenus.ForEach(m => m.ChildMenus = BuildMenuChilds(m.Id, originalList));
           return listMenus;
        }

    }
}