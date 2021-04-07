using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektuppgiftASP.NET.Data.Migrations
{
    public partial class moreChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.CreateTable(
                name: "EventMyUser",
                columns: table => new
                {
                    AttendeesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JoinedEventsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventMyUser", x => new { x.AttendeesId, x.JoinedEventsId });
                    table.ForeignKey(
                        name: "FK_EventMyUser_AspNetUsers_AttendeesId",
                        column: x => x.AttendeesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventMyUser_Event_JoinedEventsId",
                        column: x => x.JoinedEventsId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventMyUser_JoinedEventsId",
                table: "EventMyUser",
                column: "JoinedEventsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventMyUser");

            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    AttendeesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JoinedEventsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => new { x.AttendeesId, x.JoinedEventsId });
                    table.ForeignKey(
                        name: "FK_EventUser_AspNetUsers_AttendeesId",
                        column: x => x.AttendeesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUser_Event_JoinedEventsId",
                        column: x => x.JoinedEventsId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_JoinedEventsId",
                table: "EventUser",
                column: "JoinedEventsId");
        }
    }
}
