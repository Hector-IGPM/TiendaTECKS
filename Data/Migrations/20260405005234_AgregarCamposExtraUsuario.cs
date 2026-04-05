using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaOnline.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCamposExtraUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "AspNetUsers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreCompleto",
                table: "AspNetUsers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TelefonoContacto",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NombreCompleto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TelefonoContacto",
                table: "AspNetUsers");
        }
    }
}
