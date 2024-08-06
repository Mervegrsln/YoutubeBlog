using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using YoutubeBlog.Entity.Entities;


namespace YoutubeBlog.Data.Mappings
{
    public class ImageMap : IEntityTypeConfiguration<Image>

    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {
                   Id = Guid.Parse("F9B7276F-B3F2-45EE-8887-4EF475477301"),
                FileName = "images/testimage",
                    FileType = "jpg",
                    CreatedBy = "Admin Test",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false

                

            },
            new Image
            {
                Id = Guid.Parse("81DBAF02-D59A-492C-A3E9-8A32AC23C998"),
                FileName = "images/vtest",
                FileType = "png",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false

            });
        }
    }
}
