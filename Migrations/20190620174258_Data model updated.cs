using Microsoft.EntityFrameworkCore.Migrations;

namespace crudstore.Migrations
{
    public partial class Datamodelupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreNumber",
                table: "Locations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreNumber",
                table: "Locations");
        }
    }
}
