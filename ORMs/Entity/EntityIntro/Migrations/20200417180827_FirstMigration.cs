using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityIntro.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RitoMasters",
                columns: table => new
                {
                    RitoMasterId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RitoMasters", x => x.RitoMasterId);
                });

            migrationBuilder.CreateTable(
                name: "Burritos",
                columns: table => new
                {
                    BurritoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Tortilla = table.Column<string>(nullable: false),
                    Meat = table.Column<string>(nullable: false),
                    Rice = table.Column<string>(nullable: false),
                    Beans = table.Column<string>(nullable: false),
                    Vegetable = table.Column<string>(nullable: false),
                    Guac = table.Column<bool>(nullable: false),
                    RitoMasterId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burritos", x => x.BurritoId);
                    table.ForeignKey(
                        name: "FK_Burritos_RitoMasters_RitoMasterId",
                        column: x => x.RitoMasterId,
                        principalTable: "RitoMasters",
                        principalColumn: "RitoMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Burritos_RitoMasterId",
                table: "Burritos",
                column: "RitoMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Burritos");

            migrationBuilder.DropTable(
                name: "RitoMasters");
        }
    }
}
