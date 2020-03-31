using Almotkaml.Extensions;
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.EntityCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace Almotkaml.MFMinistry.EntityCore
{
    public class MFMinistryDbContext : DbContext
    {
        private readonly string _connectionString;
        internal int LoggedInUserId { get; set; }
        public MFMinistryDbContext() { }
        public MFMinistryDbContext(string connectionString, int loggedInUserId)
        {
            _connectionString = connectionString;
            LoggedInUserId = loggedInUserId;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelCreating(modelBuilder);
        }

        protected virtual void ModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>(Configurations.ConfigureUserGroup);
            modelBuilder.Entity<User>(Configurations.ConfigureUser);
            modelBuilder.Entity<Activity>(Configurations.ConfigureActivity);
            modelBuilder.Entity<Notification>(Configurations.ConfigureNotification);
            modelBuilder.Entity<Question>(Configurations.ConfigureQuestion);
            modelBuilder.Entity<City>(Configurations.ConfigureCity);
            modelBuilder.Entity<Country>(Configurations.ConfigureCountry);
            modelBuilder.Entity<Branch>(Configurations.ConfigureBranch);
            modelBuilder.Entity<Bank>(Configurations.ConfigureBank);
            modelBuilder.Entity<BankBranch>(Configurations.ConfigureBankBranch);
            modelBuilder.Entity<Setting>(Configurations.ConfigureSetting);
            modelBuilder.Entity<Info>(Configurations.ConfigureInfo);
            modelBuilder.Entity<Nationality>(Configurations.ConfigureNationality);
            modelBuilder.Entity<Grant>(Configurations.ConfigureGrant);
            modelBuilder.Entity<GrantRule>(Configurations.ConfigureGrantRule);
            modelBuilder.Entity<FormsMFM>(Configurations.ConfigureFormsMFM);
            modelBuilder.Entity<DataCollection>(Configurations.ConfigureDataCollection);
            modelBuilder.Entity<RecipientGroup>(Configurations.ConfigureRecipientGroup);
            modelBuilder.Entity<FinancialGroup>(Configurations.ConfigureFinancialGroup);
            modelBuilder.Entity<Drawer>(Configurations.ConfigureDrawer);
            modelBuilder.Entity<Department>(Configurations.ConfigureDepartment);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString == null)
            {
                optionsBuilder.UseSqlServer("Server=.; Database=AlmotkamlMFMinistry; Integrated security=true;");
                return;
            }
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            SaveUserGroups();
            SaveUsers();
            SaveGrantRules();
            // Added Entries
            var addedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added);

            foreach (var entry in addedEntries)
            {
                if (entry.Properties.Any(p => p.Metadata.Name == Configurations.DateCreated))
                    entry.Property(Configurations.DateCreated).CurrentValue = DateTime.UtcNow;

                if (entry.Properties.Any(p => p.Metadata.Name == Configurations.CreatedBy))
                    entry.Property(Configurations.CreatedBy).CurrentValue = LoggedInUserId;
            }


            // Modified Entries
            var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);

            foreach (var entry in modifiedEntries)
            {
                if (entry.Properties.Any(p => p.Metadata.Name == Configurations.DateModified))
                    entry.Property(Configurations.DateModified).CurrentValue = DateTime.UtcNow;

                if (entry.Properties.Any(p => p.Metadata.Name == Configurations.ModifiedBy))
                    entry.Property(Configurations.ModifiedBy).CurrentValue = LoggedInUserId;
            }

            // Deleted Entries

            return base.SaveChanges();
        }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Grant> Grants { get; set; }
        public DbSet<GrantRule> GrantRules { get; set; }
        public DbSet<FinancialGroup> FinancialGroups { get; set; }
        public DbSet<FormsMFM> FormsMFM { get; set; }
        public DbSet<RecipientGroup> RecipientGroups { get; set; }
        public DbSet<Drawer> Drawers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DataCollection> DataCollection { get; set; }

        #region private

        private void SaveUserGroups()
        {
            var userGroupEntries = ChangeTracker
                .Entries<UserGroup>();

            foreach (var userGroup in userGroupEntries)
            {
                var permissions = userGroup.Entity.Permissions.ToSerializedObject();
                if (permissions != userGroup.Property<string>(Configurations.Column(nameof(UserGroup.Permissions))).CurrentValue)
                {
                    userGroup.Property<string>(Configurations.Column(nameof(UserGroup.Permissions))).CurrentValue = permissions;

                    if (userGroup.State == EntityState.Unchanged)
                        userGroup.State = EntityState.Modified;
                }
            }
        }
        private void SaveGrantRules()
        {
            var userGroupEntries = ChangeTracker
                .Entries<GrantRule>();

            foreach (var userGroup in userGroupEntries)
            {
                var permissions = userGroup.Entity.grantees.ToSerializedObject();
                if (permissions != userGroup.Property<string>(Configurations.Column(nameof(GrantRule.grantees))).CurrentValue)
                {
                    userGroup.Property<string>(Configurations.Column(nameof(GrantRule.grantees))).CurrentValue = permissions;

                    if (userGroup.State == EntityState.Unchanged)
                        userGroup.State = EntityState.Modified;
                }
            }
        }
        private void SaveUsers()
        {
            var userEntries = ChangeTracker
                .Entries<User>();

            foreach (var user in userEntries)
            {
                var notify = user.Entity.Notify.ToSerializedObject();
                if (notify != user.Property<string>(Configurations.Column(nameof(User.Notify))).CurrentValue)
                {
                    user.Property<string>(Configurations.Column(nameof(User.Notify))).CurrentValue = notify;

                    var passwordProperty = user.Property(nameof(user.Entity.Password));

                    if (user.State == EntityState.Added || passwordProperty.OriginalValue != passwordProperty.CurrentValue)
                        user.Entity.SetValue(u => u.Password, user.Entity.Password.ToMd5());

                    if (user.State == EntityState.Unchanged)
                        user.State = EntityState.Modified;
                }
            }
        }

        #endregion

    }
}
