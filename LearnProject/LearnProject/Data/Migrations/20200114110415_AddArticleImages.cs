using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnProject.Data.Migrations
{
    public partial class AddArticleImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BodyId",
                table: "ArticleHeaders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ArticleBody",
                columns: table => new
                {
                    ArticleBodyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleBody", x => x.ArticleBodyId);
                });

            migrationBuilder.CreateTable(
                name: "ImageBlog",
                columns: table => new
                {
                    ImageBlogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataBytes = table.Column<byte[]>(nullable: true),
                    UploadTime = table.Column<DateTime>(nullable: false),
                    ArticleBodyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageBlog", x => x.ImageBlogId);
                    table.ForeignKey(
                        name: "FK_ImageBlog_ArticleBody_ArticleBodyId",
                        column: x => x.ArticleBodyId,
                        principalTable: "ArticleBody",
                        principalColumn: "ArticleBodyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleHeaders_BodyId",
                table: "ArticleHeaders",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageBlog_ArticleBodyId",
                table: "ImageBlog",
                column: "ArticleBodyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleHeaders_ArticleBody_BodyId",
                table: "ArticleHeaders",
                column: "BodyId",
                principalTable: "ArticleBody",
                principalColumn: "ArticleBodyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleHeaders_ArticleBody_BodyId",
                table: "ArticleHeaders");

            migrationBuilder.DropTable(
                name: "ImageBlog");

            migrationBuilder.DropTable(
                name: "ArticleBody");

            migrationBuilder.DropIndex(
                name: "IX_ArticleHeaders_BodyId",
                table: "ArticleHeaders");

            migrationBuilder.DropColumn(
                name: "BodyId",
                table: "ArticleHeaders");
        }
    }
}
