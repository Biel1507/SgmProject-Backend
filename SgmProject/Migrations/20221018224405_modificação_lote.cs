using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SgmProject.Migrations
{
    public partial class modificação_lote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Lote",
                table: "Motos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lote",
                table: "Motos");
        }
    }
}
