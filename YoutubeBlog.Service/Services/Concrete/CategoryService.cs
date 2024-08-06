﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Services.Abstractions;

namespace YoutubeBlog.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        public CategoryService(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
        {   var userId= _user.GetLoggedInUserId();
            var userEmail=_user.GetLoggedInEmail();

            var categories =await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map=mapper.Map<List<CategoryDto>>(categories);
            return map;
        }
        public async Task<string> CreateCategoryAsync(CategoryAddDto categoryAddDto)
        {
            Category category=new(categoryAddDto.Name);
            await unitOfWork.GetRepository<Category>().AddAsync(category);
        }
            
            
            }
}


