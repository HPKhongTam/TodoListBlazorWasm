using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("alter table AspNetUsers alter column FirstName nvarchar (1000)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
