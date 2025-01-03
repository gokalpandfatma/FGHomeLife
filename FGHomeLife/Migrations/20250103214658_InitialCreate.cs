using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FGHomeLife.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_BlogComments_ParentCommentId",
                table: "BlogComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_Users_UserId",
                table: "BlogComments");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "BlogComments");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BlogPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "BlogComments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "BlogComments",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(2889));

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "Name", "Slug", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2025, 1, 4, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(2890), "Özel günler için çiçek önerileri", true, "Özel Günler", "ozel-gunler", null });

            migrationBuilder.InsertData(
                table: "BlogTags",
                columns: new[] { "Id", "CreatedAt", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 4, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(3148), "Orkide", "orkide" },
                    { 2, new DateTime(2025, 1, 4, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(3353), "Gül", "gul" },
                    { 3, new DateTime(2025, 1, 4, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(3354), "Sukulent", "sukulent" },
                    { 4, new DateTime(2025, 1, 4, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(3354), "Bakım", "bakim" },
                    { 5, new DateTime(2025, 1, 4, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(3355), "İç Mekan", "ic-mekan" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "IsActive", "Name" },
                values: new object[] { 1, new DateTime(2025, 1, 4, 0, 46, 57, 641, DateTimeKind.Local).AddTicks(9082), "admin@example.com", true, "Admin User" });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedAt", "ImageUrl", "IsActive", "Slug", "Summary", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { 1, 1, "<p>Orkideler, güzellikleri ve zarafetleriyle ev dekorasyonunun vazgeçilmez parçalarından biridir. Ancak bakımları konusunda dikkatli olunması gerekir.</p>\r\n                               <h3>1. Doğru Sulama</h3>\r\n                               <p>Orkideleri haftada bir kez, ılık suyla sulayın. Saksının altındaki deliklerden su akana kadar sulama yapın.</p>\r\n                               <h3>2. Işık İhtiyacı</h3>\r\n                               <p>Direkt güneş ışığından koruyun. Parlak ama dolaylı ışık alan bir konumda tutun.</p>", new DateTime(2024, 12, 30, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(4141), "/images/blog/orkide-bakim.jpg", true, "orkide-bakiminin-puf-noktalari", "Orkidelerinizin uzun ömürlü olması için dikkat etmeniz gereken önemli bakım ipuçları.", "Orkide Bakımının Püf Noktaları", 1, 0 },
                    { 2, 2, "<p>Çiçekler, ev dekorasyonuna canlılık ve doğallık katan en önemli elementlerdir.</p>\r\n                               <h3>Oturma Odası</h3>\r\n                               <p>Büyük yapraklı bitkiler, oturma odasına tropik bir hava katabilir.</p>\r\n                               <h3>Yatak Odası</h3>\r\n                               <p>Lavanta gibi sakinleştirici çiçekler, yatak odasına huzur getirir.</p>", new DateTime(2025, 1, 1, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(4309), "/images/blog/ev-dekorasyon.jpg", true, "ev-dekorasyonunda-cicek-kullanimi", "Evinizi çiçeklerle nasıl daha şık ve yaşanılır hale getirebileceğinizi öğrenin.", "Ev Dekorasyonunda Çiçek Kullanımı", 1, 0 },
                    { 3, 3, "<p>Sevgililer günü için çiçek seçerken dikkat edilmesi gereken noktalar vardır.</p>\r\n                               <h3>Klasik Kırmızı Güller</h3>\r\n                               <p>Kırmızı güller, tutkunun ve aşkın evrensel sembolüdür.</p>\r\n                               <h3>Alternatif Seçenekler</h3>\r\n                               <p>Orkideler zarafeti, laleler ise mükemmel aşkı temsil eder.</p>", new DateTime(2025, 1, 3, 0, 46, 57, 642, DateTimeKind.Local).AddTicks(4313), "/images/blog/sevgililer-gunu.jpg", true, "sevgililer-gunu-icin-cicek-secimi", "Sevgililer gününde partnerinizi şaşırtacak çiçek önerileri ve anlamları.", "Sevgililer Günü İçin Çiçek Seçimi", 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "BlogComments",
                columns: new[] { "Id", "BlogPostId", "Content", "CreatedAt", "IsApproved", "ParentCommentId", "UserId", "UserId1" },
                values: new object[] { 1, 1, "Harika bir yazı olmuş, teşekkürler!", new DateTime(2025, 1, 3, 12, 46, 57, 642, DateTimeKind.Local).AddTicks(6006), true, null, 1, null });

            migrationBuilder.InsertData(
                table: "BlogPostTags",
                columns: new[] { "BlogPostsId", "TagsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 2, 5 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "BlogComments",
                columns: new[] { "Id", "BlogPostId", "Content", "CreatedAt", "IsApproved", "ParentCommentId", "UserId", "UserId1" },
                values: new object[] { 2, 1, "Yorumunuz için teşekkürler!", new DateTime(2025, 1, 3, 18, 46, 57, 642, DateTimeKind.Local).AddTicks(6145), true, 1, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_UserId",
                table: "BlogPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_UserId1",
                table: "BlogComments",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_BlogComments_ParentCommentId",
                table: "BlogComments",
                column: "ParentCommentId",
                principalTable: "BlogComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_Users_UserId",
                table: "BlogComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_Users_UserId1",
                table: "BlogComments",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Users_UserId",
                table: "BlogPosts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_BlogComments_ParentCommentId",
                table: "BlogComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_Users_UserId",
                table: "BlogComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_Users_UserId1",
                table: "BlogComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Users_UserId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_UserId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogComments_UserId1",
                table: "BlogComments");

            migrationBuilder.DeleteData(
                table: "BlogComments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogPostTags",
                keyColumns: new[] { "BlogPostsId", "TagsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BlogPostTags",
                keyColumns: new[] { "BlogPostsId", "TagsId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "BlogPostTags",
                keyColumns: new[] { "BlogPostsId", "TagsId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "BlogPostTags",
                keyColumns: new[] { "BlogPostsId", "TagsId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogComments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "BlogComments");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "BlogPosts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "BlogComments",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "BlogComments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 0, 14, 10, 702, DateTimeKind.Local).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 4, 0, 14, 10, 702, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "IconClass", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 4, 0, 14, 10, 702, DateTimeKind.Local).AddTicks(5429), "Aşkınızı ifade eden özel tasarımlar", "fas fa-heart", true, "Sevgiliye Çiçekler" },
                    { 2, new DateTime(2025, 1, 4, 0, 14, 10, 702, DateTimeKind.Local).AddTicks(5542), "Özel günler için özel hediyeler", "fas fa-gift", true, "Doğum Günü" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_BlogComments_ParentCommentId",
                table: "BlogComments",
                column: "ParentCommentId",
                principalTable: "BlogComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_Users_UserId",
                table: "BlogComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
