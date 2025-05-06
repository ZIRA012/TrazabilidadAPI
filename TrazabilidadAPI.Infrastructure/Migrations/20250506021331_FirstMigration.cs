using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrazabilidadAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    FieldID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.FieldID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Procedures",
                columns: table => new
                {
                    ProcedureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcedureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    LastModifiedUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.ProcedureID);
                    table.ForeignKey(
                        name: "FK_Procedures_Users_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procedures_Users_LastModifiedUserID",
                        column: x => x.LastModifiedUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataSets",
                columns: table => new
                {
                    DataSetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcedureID = table.Column<int>(type: "int", nullable: false),
                    FieldID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSets", x => x.DataSetID);
                    table.ForeignKey(
                        name: "FK_DataSets_Fields_FieldID",
                        column: x => x.FieldID,
                        principalTable: "Fields",
                        principalColumn: "FieldID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataSets_Procedures_ProcedureID",
                        column: x => x.ProcedureID,
                        principalTable: "Procedures",
                        principalColumn: "ProcedureID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataSets_FieldID",
                table: "DataSets",
                column: "FieldID");

            migrationBuilder.CreateIndex(
                name: "IX_DataSets_ProcedureID",
                table: "DataSets",
                column: "ProcedureID");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_CreatedByUserID",
                table: "Procedures",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_LastModifiedUserID",
                table: "Procedures",
                column: "LastModifiedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleID",
                table: "UserRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID",
                table: "UserRoles",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataSets");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Procedures");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
