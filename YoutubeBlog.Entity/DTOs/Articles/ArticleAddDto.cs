﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.DTOs.Categories;

namespace YoutubeBlog.Entity.DTOs.Articles
{
    public class ArticleAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid  CategoryId { get; set; }
        public IFormFile Photo { get; set; }
        public  IList<CategoryDto>?  Categories { get; set; }
    }
}
