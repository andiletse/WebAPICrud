using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedSystem1_EntityName1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "System1_TableName1",
                newName: "propertyName3");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "System1_TableName1",
                newName: "propertyName2");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "System1_TableName1",
                newName: "propertyName1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "propertyName3",
                table: "System1_TableName1",
                newName: "UserPassword");

            migrationBuilder.RenameColumn(
                name: "propertyName2",
                table: "System1_TableName1",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "propertyName1",
                table: "System1_TableName1",
                newName: "UserEmail");
        }
    }
}
