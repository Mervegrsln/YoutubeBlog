using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");
            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("58227FDC-7F5E-4351-BADC-EDFAD969EDC3"),
                RoleId = Guid.Parse("A52F97C6-C2E9-4AA7-B712-81DF32135837")
            },
                new AppUserRole
                {
                    UserId = Guid.Parse("40DBB153-21D5-4210-933F-45ACA69AACF7"),
                    RoleId = Guid.Parse("088FE54E-19EE-4645-9919-521E99C0AE87")
                });
        }
    }
}
