using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnProject.Data.Migrations
{
    public partial class AddLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleHeaders_ArticleBody_BodyId",
                table: "ArticleHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageBlog_ArticleBody_ArticleBodyId",
                table: "ImageBlog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleBody",
                table: "ArticleBody");

            migrationBuilder.RenameTable(
                name: "ArticleBody",
                newName: "ArticleBodies");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleBodies",
                table: "ArticleBodies",
                column: "ArticleBodyId");

            migrationBuilder.CreateTable(
                name: "ErrorTypes",
                columns: table => new
                {
                    ErrorTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorTypes", x => x.ErrorTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    ErrorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    ErrorTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errors", x => x.ErrorId);
                    table.ForeignKey(
                        name: "FK_Errors_ErrorTypes_ErrorTypeId",
                        column: x => x.ErrorTypeId,
                        principalTable: "ErrorTypes",
                        principalColumn: "ErrorTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Errors_ErrorTypeId",
                table: "Errors",
                column: "ErrorTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleHeaders_ArticleBodies_BodyId",
                table: "ArticleHeaders",
                column: "BodyId",
                principalTable: "ArticleBodies",
                principalColumn: "ArticleBodyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageBlog_ArticleBodies_ArticleBodyId",
                table: "ImageBlog",
                column: "ArticleBodyId",
                principalTable: "ArticleBodies",
                principalColumn: "ArticleBodyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleHeaders_ArticleBodies_BodyId",
                table: "ArticleHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageBlog_ArticleBodies_ArticleBodyId",
                table: "ImageBlog");

            migrationBuilder.DropTable(
                name: "Errors");

            migrationBuilder.DropTable(
                name: "ErrorTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleBodies",
                table: "ArticleBodies");

            migrationBuilder.RenameTable(
                name: "ArticleBodies",
                newName: "ArticleBody");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleBody",
                table: "ArticleBody",
                column: "ArticleBodyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleHeaders_ArticleBody_BodyId",
                table: "ArticleHeaders",
                column: "BodyId",
                principalTable: "ArticleBody",
                principalColumn: "ArticleBodyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageBlog_ArticleBody_ArticleBodyId",
                table: "ImageBlog",
                column: "ArticleBodyId",
                principalTable: "ArticleBody",
                principalColumn: "ArticleBodyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
