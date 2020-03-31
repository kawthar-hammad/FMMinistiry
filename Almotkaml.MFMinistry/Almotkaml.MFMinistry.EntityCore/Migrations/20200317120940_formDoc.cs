using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almotkaml.MFMinistry.EntityCore.Migrations
{
    public partial class formDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<int>(nullable: false),
                    Departmentname = table.Column<string>(maxLength: 128, nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drawers",
                columns: table => new
                {
                    DrawerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrawerNumber = table.Column<string>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawers", x => x.DrawerId);
                });

            migrationBuilder.CreateTable(
                name: "FinancialGroups",
                columns: table => new
                {
                    FinancialGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Number = table.Column<string>(nullable: true),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialGroups", x => x.FinancialGroupId);
                });

            migrationBuilder.CreateTable(
                name: "RecipientGroups",
                columns: table => new
                {
                    RecipientGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(nullable: true),
                    GroupNumber = table.Column<string>(nullable: true),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipientGroups", x => x.RecipientGroupId);
                });

            migrationBuilder.CreateTable(
                name: "FormsMFM",
                columns: table => new
                {
                    FormsMFMId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    DrawerId = table.Column<int>(nullable: false),
                    FCategory = table.Column<int>(nullable: false),
                    FStatus = table.Column<int>(nullable: false),
                    FinancialGroupId = table.Column<int>(nullable: false),
                    FormNumber = table.Column<string>(maxLength: 128, nullable: false),
                    RecipientGroupId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormsMFM", x => x.FormsMFMId);
                    table.ForeignKey(
                        name: "FK_FormsMFM_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormsMFM_Drawers_DrawerId",
                        column: x => x.DrawerId,
                        principalTable: "Drawers",
                        principalColumn: "DrawerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormsMFM_FinancialGroups_FinancialGroupId",
                        column: x => x.FinancialGroupId,
                        principalTable: "FinancialGroups",
                        principalColumn: "FinancialGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormsMFM_RecipientGroups_RecipientGroupId",
                        column: x => x.RecipientGroupId,
                        principalTable: "RecipientGroups",
                        principalColumn: "RecipientGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataCollection",
                columns: table => new
                {
                    DataCollectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 1000, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    BirthPlace = table.Column<string>(maxLength: 128, nullable: true),
                    BookFamilySourceNumber = table.Column<string>(nullable: true),
                    ChildernCount = table.Column<int>(nullable: true),
                    FatherName = table.Column<string>(maxLength: 128, nullable: true),
                    FinancialGroupId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 128, nullable: false),
                    FormsMFMId = table.Column<int>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    GrandfatherName = table.Column<string>(maxLength: 128, nullable: true),
                    LastName = table.Column<string>(maxLength: 128, nullable: true),
                    MotherName = table.Column<string>(maxLength: 1000, nullable: true),
                    NationalNumber = table.Column<string>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    Phone = table.Column<string>(maxLength: 128, nullable: true),
                    SocialStatus = table.Column<int>(nullable: false),
                    WifeNationalityId = table.Column<int>(nullable: true),
                    _CreatedBy = table.Column<int>(nullable: false),
                    _DateCreated = table.Column<DateTime>(nullable: false),
                    _DateModified = table.Column<DateTime>(nullable: false),
                    _ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataCollection", x => x.DataCollectionId);
                    table.ForeignKey(
                        name: "FK_DataCollection_FinancialGroups_FinancialGroupId",
                        column: x => x.FinancialGroupId,
                        principalTable: "FinancialGroups",
                        principalColumn: "FinancialGroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataCollection_FormsMFM_FormsMFMId",
                        column: x => x.FormsMFMId,
                        principalTable: "FormsMFM",
                        principalColumn: "FormsMFMId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataCollection_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "NationalityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataCollection_Nationalities_WifeNationalityId",
                        column: x => x.WifeNationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "NationalityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataCollection_FinancialGroupId",
                table: "DataCollection",
                column: "FinancialGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DataCollection_FormsMFMId",
                table: "DataCollection",
                column: "FormsMFMId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataCollection_NationalityId",
                table: "DataCollection",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_DataCollection_WifeNationalityId",
                table: "DataCollection",
                column: "WifeNationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BranchId",
                table: "Departments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FormsMFM_DepartmentId",
                table: "FormsMFM",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FormsMFM_DrawerId",
                table: "FormsMFM",
                column: "DrawerId");

            migrationBuilder.CreateIndex(
                name: "IX_FormsMFM_FinancialGroupId",
                table: "FormsMFM",
                column: "FinancialGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FormsMFM_RecipientGroupId",
                table: "FormsMFM",
                column: "RecipientGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataCollection");

            migrationBuilder.DropTable(
                name: "FormsMFM");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Drawers");

            migrationBuilder.DropTable(
                name: "FinancialGroups");

            migrationBuilder.DropTable(
                name: "RecipientGroups");
        }
    }
}
