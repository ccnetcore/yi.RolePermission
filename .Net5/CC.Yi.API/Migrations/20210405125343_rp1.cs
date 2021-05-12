using Microsoft.EntityFrameworkCore.Migrations;

namespace CC.Yi.API.Migrations
{
    public partial class rp1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "info_action",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    action_name = table.Column<string>(type: "TEXT", nullable: true),
                    is_delete = table.Column<int>(type: "INTEGER", nullable: false),
                    router = table.Column<string>(type: "TEXT", nullable: true),
                    icon = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_action", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "info_role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    role_name = table.Column<string>(type: "TEXT", nullable: true),
                    is_delete = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "info_user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_name = table.Column<string>(type: "TEXT", nullable: true),
                    password = table.Column<string>(type: "TEXT", nullable: true),
                    is_delete = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "info_actioninfo_role",
                columns: table => new
                {
                    Info_ActionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    info_RolesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_actioninfo_role", x => new { x.Info_ActionsId, x.info_RolesId });
                    table.ForeignKey(
                        name: "FK_info_actioninfo_role_info_action_Info_ActionsId",
                        column: x => x.Info_ActionsId,
                        principalTable: "info_action",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_info_actioninfo_role_info_role_info_RolesId",
                        column: x => x.info_RolesId,
                        principalTable: "info_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "info_actioninfo_user",
                columns: table => new
                {
                    Info_ActionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    Info_UsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_actioninfo_user", x => new { x.Info_ActionsId, x.Info_UsersId });
                    table.ForeignKey(
                        name: "FK_info_actioninfo_user_info_action_Info_ActionsId",
                        column: x => x.Info_ActionsId,
                        principalTable: "info_action",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_info_actioninfo_user_info_user_Info_UsersId",
                        column: x => x.Info_UsersId,
                        principalTable: "info_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "info_roleinfo_user",
                columns: table => new
                {
                    Info_RolesId = table.Column<int>(type: "INTEGER", nullable: false),
                    Info_UsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info_roleinfo_user", x => new { x.Info_RolesId, x.Info_UsersId });
                    table.ForeignKey(
                        name: "FK_info_roleinfo_user_info_role_Info_RolesId",
                        column: x => x.Info_RolesId,
                        principalTable: "info_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_info_roleinfo_user_info_user_Info_UsersId",
                        column: x => x.Info_UsersId,
                        principalTable: "info_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_info_actioninfo_role_info_RolesId",
                table: "info_actioninfo_role",
                column: "info_RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_info_actioninfo_user_Info_UsersId",
                table: "info_actioninfo_user",
                column: "Info_UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_info_roleinfo_user_Info_UsersId",
                table: "info_roleinfo_user",
                column: "Info_UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "info_actioninfo_role");

            migrationBuilder.DropTable(
                name: "info_actioninfo_user");

            migrationBuilder.DropTable(
                name: "info_roleinfo_user");

            migrationBuilder.DropTable(
                name: "info_action");

            migrationBuilder.DropTable(
                name: "info_role");

            migrationBuilder.DropTable(
                name: "info_user");
        }
    }
}
