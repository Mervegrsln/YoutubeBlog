using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;


namespace YoutubeBlog.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "Aspnet Core Deneme Makalesi",
                Content = "https://dergipark.org.tr/tr/pub/estudambilisim/issue/60018/846937#article-authors-list",
                ViewCount = 15,
               
                CategoryId= Guid.Parse("C0D446A3-D1D2-4CB8-92A7-BDE5CDEEC95A"),
                ImageId= Guid.Parse("F9B7276F-B3F2-45EE-8887-4EF475477301"),
                CreatedBy = "Admin test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId=Guid.Parse("58227FDC-7F5E-4351-BADC-EDFAD969EDC3")
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Visual Studio Deneme Makalesi",
                Content = "visual studio https://dergipark.org.tr/tr/pub/estudambilisim/issue/60018/846937#article-authors-list",
                ViewCount = 15,
               CategoryId= Guid.Parse("C1066226-E8F4-4D6B-897A-99CD67E96A9A"),
               ImageId= Guid.Parse("81DBAF02-D59A-492C-A3E9-8A32AC23C998"),
                CreatedBy = "Admin test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId= Guid.Parse("40DBB153-21D5-4210-933F-45ACA69AACF7")
            }

            );
        }
    }
}