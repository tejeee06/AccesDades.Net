using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitesMediques.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visites Mediques",
                columns: table => new
                {
                    Id_Visita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Pacient = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Nom_Metge = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    Diagnostic = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visites Mediques", x => x.Id_Visita);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visites Mediques");
        }
    }
}
