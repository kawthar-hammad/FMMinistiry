using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Almotkaml.MFMinistry.EntityCore.Migrations
{
    public partial class UpdateTblAvtivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Activities",
                newName: "ActivityDate");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Activities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "ActivityDate",
                table: "Activities",
                newName: "DateTime");
        }
    }
}
