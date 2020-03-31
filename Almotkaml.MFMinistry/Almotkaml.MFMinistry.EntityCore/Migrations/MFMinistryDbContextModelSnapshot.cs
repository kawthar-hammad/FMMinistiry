using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Almotkaml.MFMinistry.EntityCore;
using Almotkaml.MFMinistry;

namespace Almotkaml.MFMinistry.EntityCore.Migrations
{
    [DbContext(typeof(MFMinistryDbContext))]
    partial class MFMinistryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.Activity", b =>
                {
                    b.Property<long>("ActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActivityDate");

                    b.Property<string>("Description");

                    b.Property<int>("FiredBy_UserId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("ActivityId");

                    b.HasIndex("FiredBy_UserId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.Bank", b =>
                {
                    b.Property<int>("BankId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("BankId");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.BankBranch", b =>
                {
                    b.Property<int>("BankBranchId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountingManualId");

                    b.Property<int>("BankId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("BankBranchId");

                    b.HasIndex("BankId");

                    b.ToTable("BankBranches");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("BranchId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.DataCollection", b =>
                {
                    b.Property<int>("DataCollectionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("BirthPlace")
                        .HasMaxLength(128);

                    b.Property<string>("BookFamilySourceNumber");

                    b.Property<int?>("ChildernCount");

                    b.Property<string>("FatherName")
                        .HasMaxLength(128);

                    b.Property<int?>("FinancialGroupId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int?>("FormsMFMId");

                    b.Property<int>("Gender");

                    b.Property<string>("GrandfatherName")
                        .HasMaxLength(128);

                    b.Property<string>("LastName")
                        .HasMaxLength(128);

                    b.Property<string>("MotherName")
                        .HasMaxLength(1000);

                    b.Property<string>("NationalNumber");

                    b.Property<int?>("NationalityId");

                    b.Property<string>("Phone")
                        .HasMaxLength(128);

                    b.Property<int>("SocialStatus");

                    b.Property<int?>("WifeNationalityId");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("DataCollectionId");

                    b.HasIndex("FinancialGroupId");

                    b.HasIndex("FormsMFMId")
                        .IsUnique();

                    b.HasIndex("NationalityId");

                    b.HasIndex("WifeNationalityId");

                    b.ToTable("DataCollection");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BranchId");

                    b.Property<string>("Departmentname")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("DepartmentId");

                    b.HasIndex("BranchId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.Drawer", b =>
                {
                    b.Property<int>("DrawerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DrawerNumber")
                        .IsRequired();

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("DrawerId");

                    b.ToTable("Drawers");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.FinancialGroup", b =>
                {
                    b.Property<int>("FinancialGroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Number");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("FinancialGroupId");

                    b.ToTable("FinancialGroups");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.FormsMFM", b =>
                {
                    b.Property<int>("FormsMFMId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentId");

                    b.Property<int>("DrawerId");

                    b.Property<int>("FCategory");

                    b.Property<int>("FStatus");

                    b.Property<int>("FinancialGroupId");

                    b.Property<string>("FormNumber")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("RecipientGroupId");

                    b.Property<int>("Type");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("FormsMFMId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DrawerId");

                    b.HasIndex("FinancialGroupId");

                    b.HasIndex("RecipientGroupId");

                    b.ToTable("FormsMFM");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.Grant", b =>
                {
                    b.Property<int>("GrantId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("GrantId");

                    b.ToTable("Grants");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.GrantRule", b =>
                {
                    b.Property<int>("GrantRuleId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GrantId")
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.Property<string>("_grantees")
                        .IsRequired();

                    b.HasKey("GrantRuleId");

                    b.HasIndex("GrantId");

                    b.ToTable("GrantRules");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.Nationality", b =>
                {
                    b.Property<int>("NationalityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("NationalityId");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.Notification", b =>
                {
                    b.Property<long>("NotificationId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ActivityId");

                    b.Property<bool>("IsRead");

                    b.Property<int>("Receiver_UserId");

                    b.HasKey("NotificationId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("Receiver_UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.RecipientGroup", b =>
                {
                    b.Property<int>("RecipientGroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GroupName");

                    b.Property<string>("GroupNumber");

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.HasKey("RecipientGroupId");

                    b.ToTable("RecipientGroups");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CheckUserPerm");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("UserGroupId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.Property<string>("_Notify")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.HasIndex("UserGroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.UserGroup", b =>
                {
                    b.Property<int>("UserGroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("_CreatedBy");

                    b.Property<DateTime>("_DateCreated");

                    b.Property<DateTime>("_DateModified");

                    b.Property<int>("_ModifiedBy");

                    b.Property<string>("_Permissions")
                        .IsRequired();

                    b.HasKey("UserGroupId");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.EntityCore.Entities.Info", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value")
                        .HasMaxLength(1000);

                    b.HasKey("Name");

                    b.ToTable("Infos");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.EntityCore.Entities.Setting", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value")
                        .HasMaxLength(1000);

                    b.HasKey("Name");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.Activity", b =>
                {
                    b.HasOne("Almotkaml.MFMinistry.Domain.User", "FiredBy_User")
                        .WithMany("Activities")
                        .HasForeignKey("FiredBy_UserId");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.BankBranch", b =>
                {
                    b.HasOne("Almotkaml.MFMinistry.Domain.Bank", "Bank")
                        .WithMany("BankBranchs")
                        .HasForeignKey("BankId");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.City", b =>
                {
                    b.HasOne("Almotkaml.MFMinistry.Domain.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.DataCollection", b =>
                {
                    b.HasOne("Almotkaml.MFMinistry.Domain.FinancialGroup")
                        .WithMany("DataCollections")
                        .HasForeignKey("FinancialGroupId");

                    b.HasOne("Almotkaml.MFMinistry.Domain.FormsMFM", "FormsMFM")
                        .WithOne("DataCollections")
                        .HasForeignKey("Almotkaml.MFMinistry.Domain.DataCollection", "FormsMFMId");

                    b.HasOne("Almotkaml.MFMinistry.Domain.Nationality", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId");

                    b.HasOne("Almotkaml.MFMinistry.Domain.Nationality", "WifeNationality")
                        .WithMany()
                        .HasForeignKey("WifeNationalityId");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.Department", b =>
                {
                    b.HasOne("Almotkaml.MFMinistry.Domain.Branch", "Branch")
                        .WithMany("Departments")
                        .HasForeignKey("BranchId");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.FormsMFM", b =>
                {
                    b.HasOne("Almotkaml.MFMinistry.Domain.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Almotkaml.MFMinistry.Domain.Drawer", "Drawer")
                        .WithMany("FormsMFM")
                        .HasForeignKey("DrawerId");

                    b.HasOne("Almotkaml.MFMinistry.Domain.FinancialGroup", "FinancialGroup")
                        .WithMany("FormsMFM")
                        .HasForeignKey("FinancialGroupId");

                    b.HasOne("Almotkaml.MFMinistry.Domain.RecipientGroup", "RecipientGroup")
                        .WithMany("FormsMFM")
                        .HasForeignKey("RecipientGroupId");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.GrantRule", b =>
                {
                    b.HasOne("Almotkaml.MFMinistry.Domain.Grant", "Grant")
                        .WithMany("GrantRules")
                        .HasForeignKey("GrantId");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.Notification", b =>
                {
                    b.HasOne("Almotkaml.MFMinistry.Domain.Activity", "Activity")
                        .WithMany("Notifications")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Almotkaml.MFMinistry.Domain.User", "Receiver_User")
                        .WithMany("Notifications")
                        .HasForeignKey("Receiver_UserId");
                });

            modelBuilder.Entity("Almotkaml.MFMinistry.Domain.User", b =>
                {
                    b.HasOne("Almotkaml.MFMinistry.Domain.UserGroup", "UserGroup")
                        .WithMany("Users")
                        .HasForeignKey("UserGroupId");
                });
        }
    }
}
