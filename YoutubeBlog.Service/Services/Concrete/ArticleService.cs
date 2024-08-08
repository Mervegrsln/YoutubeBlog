using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Articles;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Helpers.Images;
using YoutubeBlog.Entity.Entities.Enums;
using System.Net.Mime;

namespace YoutubeBlog.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper imageHelper;
        private readonly ClaimsPrincipal _user;
        public ArticleService(IUnitOfWork unitWork, IMapper mapper, IHttpContextAccessor httpContextAccessor,IImageHelper imageHelper)
        {
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.imageHelper = imageHelper;
            this.UnitOfWork = unitWork;
            _user = httpContextAccessor.HttpContext.User;

        }




        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {

           // var userId = Guid.Parse("58227FDC-7F5E-4351-BADC-EDFAD969EDC3"); kendim vermiştim altta otomatik olarak değiştirdim.
            var userId=_user.GetLoggedInUserId();
            var userEmail=_user.GetLoggedInEmail();

            var imageUpLoad = await imageHelper.Upload(articleAddDto.Title,articleAddDto.Photo,ImageType.Post);
            Image image = new(imageUpLoad.FullName, articleAddDto.Photo.ContentType, userEmail);
            await UnitOfWork.GetRepository<Image>().AddAsync(image);    
            // var imageId = Guid.Parse("F9B7276F-B3F2-45EE-8887-4EF475477301"); null geçilemez olduğu için geçici değer olarak atadım.
            var article = new Article(articleAddDto.Title, articleAddDto.Content, userId,userEmail, articleAddDto.CategoryId, image.Id);
            
            await UnitOfWork.GetRepository<Article>().AddAsync(article);
            await UnitOfWork.SaveAsync();

        }

        

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await UnitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
            var map = mapper.Map<List<ArticleDto>>(articles);
            return map;
        }
        public async Task<ArticleDto>GetArticleWithCategoryNonDeletedAsync(Guid articleId)
        {
            var article = await UnitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted&&x.Id==articleId, x => x.Category, i => i.Image);
            var map = mapper.Map<ArticleDto>(article);
            return map;
        }
        public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await UnitOfWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category, i => i.Image);


            if (articleUpdateDto.Photo != null)
            {
                if(article.Image != null)
                    imageHelper.Delete(article.Image.FileName);
                var imageUpload = await imageHelper.Upload(articleUpdateDto.Title, articleUpdateDto.Photo, ImageType.Post);
                Image image = new(imageUpload.FullName, articleUpdateDto.Photo.ContentType, userEmail);
                await UnitOfWork.GetRepository<Image>().AddAsync(image);
                article.ImageId = image.Id;
            }
            //burda map işlemi yapmıştım fakat imageyi null olarak değiştirdiği için kod çalışmıyordu.
            //mapper.Map<ArticleUpdateDto,Article>(articleUpdateDto,article);
            string articleTitleBeforeUpdate = article.Title;
            article.Title = articleUpdateDto.Title;
            article.Content = articleUpdateDto.Content;
            article.CategoryId = articleUpdateDto.CategoryId;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;
            await UnitOfWork.GetRepository<Article>().UpdateAsync(article);
            await UnitOfWork.SaveAsync();

            return articleTitleBeforeUpdate;
        }

            public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
           var userEmail=_user.GetLoggedInEmail();
            var article=await UnitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
           article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy=userEmail;
           await UnitOfWork.GetRepository<Article>().UpdateAsync(article);
            await UnitOfWork.SaveAsync();
            return article.Title;
        }
            
            
            }
}


