using Almotkaml.MFMinistry;
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.EntityCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Security.Cryptography;
using System.Text;


namespace Almotkaml.MFMinistry.EntityCore
{
    public static class Configurations
    {
        public static string DateCreated => "_" + nameof(DateCreated);
        public static string DateModified => "_" + nameof(DateModified);
        public static string CreatedBy => "_" + nameof(CreatedBy);
        public static string ModifiedBy => "_" + nameof(ModifiedBy);
        public static string Column(string name) => "_" + name;
        public static int SmallField => 128;
        public static int MidField => 1000;
        public static int BigField => 4000;
        public static string DecimalField => "decimal(18,10)";

        public static string ToMd5(this string value)
        {
            var x = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(value);
            bs = x.ComputeHash(bs);
            var s = new StringBuilder();
            foreach (var b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }

        private static void SharedConfigurations<TEntityBuilder>(TEntityBuilder entity)
        where TEntityBuilder : EntityTypeBuilder
        {
            entity.Property<DateTime>(DateCreated);
            entity.Property<DateTime>(DateModified);
            entity.Property<int>(CreatedBy);
            entity.Property<int>(ModifiedBy);
        }
        public static void ConfigureUserGroup(EntityTypeBuilder<UserGroup> userGroup)
        {
            userGroup.Property(g => g.Name).HasMaxLength(SmallField).IsRequired();
            userGroup.Ignore(g => g.Permissions);
            userGroup.Property<string>(Column(nameof(UserGroup.Permissions))).IsRequired();
            userGroup.HasMany(g => g.Users).WithOne(u => u.UserGroup).OnDelete(DeleteBehavior.Restrict);
            SharedConfigurations(userGroup);
        }
        public static void ConfigureGrant(EntityTypeBuilder<Grant> grants)
        {
            grants.Property(a => a.Name).IsRequired().HasMaxLength(SmallField);
            grants.HasMany(e => e.GrantRules).WithOne(e => e.Grant).OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(grants);
        }
        public static void ConfigureGrantRule(EntityTypeBuilder<GrantRule> grantRules)
        {
            grantRules.Property(g => g.GrantId).HasMaxLength(SmallField).IsRequired().HasMaxLength(SmallField);
            grantRules.Ignore(g => g.grantees);
            grantRules.Property<string>(Column(nameof(GrantRule.grantees))).IsRequired();
            grantRules.HasOne(p => p.Grant)
               .WithMany(b => b.GrantRules)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(grantRules);
        }


        public static void ConfigureUser(EntityTypeBuilder<User> user)
        {
            user.Property(u => u.UserName).HasMaxLength(SmallField).IsRequired();
            user.Property(u => u.Title).HasMaxLength(SmallField).IsRequired();
            user.Property(u => u.Password).HasMaxLength(SmallField).IsRequired();
            user.Ignore(u => u.Notify);
            user.Property<string>(Column(nameof(User.Notify))).IsRequired();
            user.HasOne(u => u.UserGroup).WithMany(g => g.Users).OnDelete(DeleteBehavior.Restrict);
            user.HasMany(u => u.Activities).WithOne(a => a.FiredBy_User).OnDelete(DeleteBehavior.Restrict);
            user.HasMany(u => u.Notifications).WithOne(n => n.Receiver_User).OnDelete(DeleteBehavior.Restrict);
            user.HasMany(a => a.Activities).WithOne().OnDelete(DeleteBehavior.Restrict);
            SharedConfigurations(user);
        }

        public static void ConfigureActivity(EntityTypeBuilder<Activity> activity)
        {
            activity.Property(a => a.Type).HasMaxLength(SmallField).IsRequired();
            activity.HasOne(a => a.FiredBy_User).WithMany(u => u.Activities).OnDelete(DeleteBehavior.Restrict);
            activity.HasMany(a => a.Notifications).WithOne(n => n.Activity).OnDelete(DeleteBehavior.Cascade);
        }

        public static void ConfigureNotification(EntityTypeBuilder<Notification> notification)
        {
            notification.HasOne(n => n.Receiver_User).WithMany(u => u.Notifications).OnDelete(DeleteBehavior.Restrict);
            notification.HasOne(n => n.Activity).WithMany(a => a.Notifications).OnDelete(DeleteBehavior.Cascade);
        }
        public static void ConfigureQuestion(EntityTypeBuilder<Question> question)
        {
            question.Property(a => a.Name).IsRequired().HasMaxLength(SmallField);
            SharedConfigurations(question);

        }


        public static void ConfigureCity(EntityTypeBuilder<City> city)
        {
            city.Property(p => p.Name).IsRequired().HasMaxLength(SmallField);
            city.HasOne(p => p.Country)
               .WithMany(b => b.Cities)
                .OnDelete(DeleteBehavior.Restrict);
          

            SharedConfigurations(city);
        }
        public static void ConfigureCountry(EntityTypeBuilder<Country> country)
        {
            country.Property(s => s.Name).IsRequired().HasMaxLength(SmallField);
            country.HasMany(e => e.Cities).WithOne(e => e.Country).OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(country);
        }

        public static void ConfigureSetting(EntityTypeBuilder<Setting> setting)
        {
            setting.HasKey(s => s.Name);
            setting.Property(s => s.Value).HasMaxLength(MidField);
        }
        public static void ConfigureInfo(EntityTypeBuilder<Info> info)
        {
            info.HasKey(s => s.Name);
            info.Property(s => s.Value).HasMaxLength(MidField);
        }
        public static void ConfigureBranch(EntityTypeBuilder<Branch> branch)
        {
            branch.Property(a => a.Name).IsRequired().HasMaxLength(SmallField);

            branch.HasMany(b => b.Departments)
                .WithOne(b => b.Branch)
                .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(branch);

        }
        public static void ConfigureBank(EntityTypeBuilder<Bank> bank)
        {
            bank.Property(s => s.Name).IsRequired().HasMaxLength(SmallField);
            bank.HasMany(e => e.BankBranchs).WithOne(e => e.Bank).OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(bank);
        }

        public static void ConfigureBankBranch(EntityTypeBuilder<BankBranch> bankBranch)
        {
            bankBranch.Property(p => p.Name).IsRequired().HasMaxLength(SmallField);
            bankBranch.HasOne(p => p.Bank)
                .WithMany(b => b.BankBranchs)
                .OnDelete(DeleteBehavior.Restrict);

            //bankBranch.Ignore(b => b.Employees);
            SharedConfigurations(bankBranch);

            //bankBranch.HasMany(j => j.Employees).WithOne(e => e.JobInfo.FinancialData.BankBranch).OnDelete(DeleteBehavior.Restrict);
        }
        public static void ConfigureNationality(EntityTypeBuilder<Nationality> nationality)
        {
            nationality.Property(m => m.Name).IsRequired().HasMaxLength(SmallField);

            SharedConfigurations(nationality);
            //nationality.HasMany(n => n.Employees)
              //  .WithOne(e => e.Nationality)
              //  .OnDelete(DeleteBehavior.Restrict);
        }

        public static void ConfigureFormsMFM(EntityTypeBuilder<FormsMFM> formsMFM)
        {
            formsMFM.Property(p => p.FormNumber).IsRequired().HasMaxLength(SmallField);
            formsMFM.HasOne(e => e.DataCollections)
               .WithOne(b => b.FormsMFM)
               .HasForeignKey<DataCollection>("FormsMFMId")
               .OnDelete(DeleteBehavior.Restrict);

            formsMFM.HasOne(e => e.FinancialGroup)
             .WithMany(e => e.FormsMFM)
             .HasForeignKey(e => e.FinancialGroupId)
             .OnDelete(DeleteBehavior.Restrict);

            formsMFM.HasOne(e => e.RecipientGroup)
            .WithMany(e => e.FormsMFM)
            .HasForeignKey(e => e.RecipientGroupId)
            .OnDelete(DeleteBehavior.Restrict);

            formsMFM.HasOne(e => e.Drawer)
           .WithMany(e => e.FormsMFM)
           .HasForeignKey(e => e.DrawerId)
           .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(formsMFM);
            
        }
        public static void ConfigureDataCollection(EntityTypeBuilder<DataCollection> dataCollection)
        {
            dataCollection.Property(e => e.FirstName).IsRequired().HasMaxLength(SmallField);
            dataCollection.Property(e => e.Address).HasMaxLength(MidField);
            dataCollection.Property(e => e.BirthPlace).HasMaxLength(SmallField);
            dataCollection.Property(e => e.FatherName).HasMaxLength(SmallField);
            dataCollection.Property(e => e.GrandfatherName).HasMaxLength(SmallField);
            dataCollection.Property(e => e.LastName).HasMaxLength(SmallField);
            dataCollection.Property(e => e.Phone).HasMaxLength(SmallField);
            dataCollection.Property(e => e.MotherName).HasMaxLength(MidField);
            SharedConfigurations(dataCollection);
            //dataCollection.HasOne(e => e.FinancialGroup)
            //  .WithMany(e => e.DataCollections)
            //  .HasForeignKey(e => e.FinancialGroupId)
            //  .OnDelete(DeleteBehavior.Restrict);

        }

        public static void ConfigureRecipientGroup(EntityTypeBuilder<RecipientGroup> group)
        {
            //dataCollection.Property(p => p.Name).IsRequired().HasMaxLength(SmallField);
            //dataCollection.HasOne(e => e.FinancialGroup)
            //  .WithMany(e => e.DataCollections)
            //  .HasForeignKey(e => e.FinancialGroupId)
            //  .OnDelete(DeleteBehavior.Restrict);

            SharedConfigurations(group);

        }
        public static void ConfigureFinancialGroup(EntityTypeBuilder<FinancialGroup> financialGroup)
        {
            financialGroup.Property(p => p.Name).IsRequired().HasMaxLength(SmallField);


            SharedConfigurations(financialGroup);

        }
        public static void ConfigureDrawer(EntityTypeBuilder<Drawer> financialGroup)
        {
            financialGroup.Property(p => p.DrawerNumber).IsRequired();//.HasMaxLength(SmallField);


            SharedConfigurations(financialGroup);

        }

        public static void ConfigureDepartment(EntityTypeBuilder<Department> Department)
        {
            Department.Property(p => p.Departmentname).IsRequired().HasMaxLength(SmallField);
            Department.HasOne(p => p.Branch)
                .WithMany(b => b.Departments)
                .OnDelete(DeleteBehavior.Restrict);
            SharedConfigurations(Department);
        }
    }
}
