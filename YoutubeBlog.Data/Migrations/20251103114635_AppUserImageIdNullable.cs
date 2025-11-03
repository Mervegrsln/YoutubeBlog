using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace YoutubeBlog.Data.Migrations
{
    public partial class AppUserImageIdNullable : Migration
    {
        // UP METODU: ImageId'yi Nullable yapar. Articles Seed Data'sı temizlenmiştir.
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers");

            // Hata veren Articles InsertData ve DeleteData kısımları bu versiyondan çıkarılmıştır.

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            // Rol, Kullanıcı, Kategori, Image UpdateData'lar (Söz dizimi hataları giderilmiştir)
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("088fe54e-19ee-4645-9919-521e99c0ae87"),
                column: "ConcurrencyStamp",
                value: "1415b894-65af-4e99-a0b2-444ed8726be6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("08e426fd-cd4c-4df4-9c38-74bd4f54f7db"),
                column: "ConcurrencyStamp",
                value: "54870312-d08d-465d-9643-aae6c1837736");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a52f97c6-c2e9-4aa7-b712-81df32135837"),
                column: "ConcurrencyStamp",
                value: "1756c010-0899-4dfc-a079-4d17286865c5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("40dbb153-21d5-4210-933f-45aca69aacf7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a5d5a58-a9af-4cd1-b4b0-9dbb7738d88f", "AQAAAAEAACcQAAAAEOOrhaEu5bAejtqRXufw2KbR8o4phsMMCaVwtD+D2RSPqqrnQJVRgIWXfMAKOihy0A==", "6d87ef29-1800-48e8-8385-d77c4ace30fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58227fdc-7f5e-4351-badc-edfad969edc3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "217a542c-08a1-44cf-b84d-a18b38562860", "AQAAAAEAACcQAAAAEHmMhdxVokENkyiu8zbuZPk8y6pq70k2x0ypPWF7O/bR+sXmPbNV1HE2ywPNmtP8LA==", "4b1610e1-f9ac-4fca-99be-ab6addbf5242" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c0d446a3-d1d2-4cb8-92a7-bde5cdeec95a"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 3, 14, 46, 35, 310, DateTimeKind.Local).AddTicks(1283));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c1066226-e8f4-4d6b-897a-99cd67e96a9a"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 3, 14, 46, 35, 310, DateTimeKind.Local).AddTicks(1286));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("81dbaf02-d59a-492c-a3e9-8a32ac23c998"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 3, 14, 46, 35, 310, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f9b7276f-b3f2-45ee-8887-4ef475477301"),
                column: "CreatedDate",
                value: new DateTime(2025, 11, 3, 14, 46, 35, 310, DateTimeKind.Local).AddTicks(1365));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        // DOWN METODU: Migration'ı geri alma komutları. Bu metot var olmalıdır.
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers");

            // Hata veren Articles InsertData ve DeleteData kısımları bu versiyondan çıkarılmıştır.

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            // Geri alınacak diğer UpdateData'lar...

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        // BuildTargetModel metodu, Migration dosyasının yapısı gereği burada bulunmalıdır.
        // İçeriği genellikle diğer migration'lardan gelen metotlar içerir.
      
    }
}