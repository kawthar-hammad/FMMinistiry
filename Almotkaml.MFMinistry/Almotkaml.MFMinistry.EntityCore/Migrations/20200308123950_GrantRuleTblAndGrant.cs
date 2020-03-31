using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.MFMinistry.EntityCore.Migrations
{
    public partial class GrantRuleTblAndGrant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_Permissions",
                table: "GrantRules",
                newName: "_grantees");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "GrantRules",
                newName: "GrantId");

            migrationBuilder.CreateTable(
                name: "Grants",
                columns: table => new
                {
                    GrantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grants", x => x.GrantId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrantRules_GrantId",
                table: "GrantRules",
                column: "GrantId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrantRules_Grants_GrantId",
                table: "GrantRules",
                column: "GrantId",
                principalTable: "Grants",
                principalColumn: "GrantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrantRules_Grants_GrantId",
                table: "GrantRules");

            migrationBuilder.DropTable(
                name: "Grants");

            migrationBuilder.DropIndex(
                name: "IX_GrantRules_GrantId",
                table: "GrantRules");

            migrationBuilder.RenameColumn(
                name: "_grantees",
                table: "GrantRules",
                newName: "_Permissions");

            migrationBuilder.RenameColumn(
                name: "GrantId",
                table: "GrantRules",
                newName: "Name");
        }
    }
}
