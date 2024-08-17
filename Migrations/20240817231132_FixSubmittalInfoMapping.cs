using Microsoft.EntityFrameworkCore.Migrations;

namespace PrepareSubmittalTool.Migrations
{
    public partial class FixSubmittalInfoMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTS",
                columns: table => new
                {
                    Client_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Client_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTS", x => x.Client_ID);
                });

            migrationBuilder.CreateTable(
                name: "PROJECTS",
                columns: table => new
                {
                    Project_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Project_Name = table.Column<string>(nullable: true),
                    Client_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECTS", x => x.Project_ID);
                    table.ForeignKey(
                        name: "FK_PROJECTS_CLIENTS_Client_ID",
                        column: x => x.Client_ID,
                        principalTable: "CLIENTS",
                        principalColumn: "Client_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SUBMITTAL",
                columns: table => new
                {
                    Submittal_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Submittal_Number = table.Column<int>(nullable: false),
                    Project_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBMITTAL", x => x.Submittal_ID);
                    table.ForeignKey(
                        name: "FK_SUBMITTAL_PROJECTS_Project_ID",
                        column: x => x.Project_ID,
                        principalTable: "PROJECTS",
                        principalColumn: "Project_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SUBMITTAL_INFO",
                columns: table => new
                {
                    Submittal_Info_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Submittal_ID = table.Column<int>(nullable: false),
                    Who_Prepared = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Filter = table.Column<string>(nullable: true),
                    Submittal_Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBMITTAL_INFO", x => x.Submittal_Info_ID);
                    table.ForeignKey(
                        name: "FK_SUBMITTAL_INFO_SUBMITTAL_Submittal_ID",
                        column: x => x.Submittal_ID,
                        principalTable: "SUBMITTAL",
                        principalColumn: "Submittal_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PROJECTS_Client_ID",
                table: "PROJECTS",
                column: "Client_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUBMITTAL_Project_ID",
                table: "SUBMITTAL",
                column: "Project_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUBMITTAL_INFO_Submittal_ID",
                table: "SUBMITTAL_INFO",
                column: "Submittal_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SUBMITTAL_INFO");

            migrationBuilder.DropTable(
                name: "SUBMITTAL");

            migrationBuilder.DropTable(
                name: "PROJECTS");

            migrationBuilder.DropTable(
                name: "CLIENTS");
        }
    }
}
