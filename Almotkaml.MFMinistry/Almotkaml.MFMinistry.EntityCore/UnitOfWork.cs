using Almotkaml.MFMinistry.Repository;
using Almotkaml;
using Almotkaml.Extensions;
using Almotkaml.MFMinistry.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Resources;
using Almotkaml.MFMinistry.EntityCore.Resource;
using Almotkaml.MFMinistry.EntityCore.Repositories;

namespace Almotkaml.MFMinistry.EntityCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppConfig _appConfig;
        private IActivityRepository _activities;
        private IUserRepository _users;
        private IUserGroupRepository _userGroups;
        private ISettingRepository _settings;
        private ICompanyInfoRepository _companyInfo;
        private INationalityRepository _nationalities;
        private IQuestionRepository _questions;
        private IBankRepository _banks;
        private IBankBranchRepository _bankBranches;
        private IBranchRepository _branches;
        private ICityRepository _cities;
        private ICountryRepository _countries;
        private IGrantRepository _grants;
        private IGrantRuleRepository _grantrules;
        private IFinancialGroupRepository _financialGroups;
        private IGroupRepository _recipientGroup;
        private IDrawerRepository _drawer;
        private IDepartmentRepository _department;
        private IMartyrRepository _martyrForm;
        private IMissingRepository _missingForm;

        protected UnitOfWork(AppConfig appConfig, int loggedInUserId = 0)
        {
            _appConfig = appConfig;
            Check.NotNull(appConfig, nameof(appConfig));
            Context = new MFMinistryDbContext(appConfig.ConnectionString, loggedInUserId);

            if (!Context.Database.GetPendingMigrations().Any())
                return;

            Context.Database.Migrate();
            SeedData.Load(Context);
        }

        protected MFMinistryDbContext Context { get; }

        public void Dispose()
        {
            Context.Dispose();
        }

        public bool TryComplete()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                Message = e.ToString();

                if (e.InnerException?.Message.Contains("table \"dbo.") ?? false)
                {
                    var tableName = e.InnerException.Message.Between("table \"dbo.", '"');
                    var name = new ResourceManager(typeof(Tables)).GetString(tableName);
                    Message = Messages.UnableToDelete + " "
                              + (string.IsNullOrWhiteSpace(name) ? tableName : name);
                }
                if (e.Message.Contains("' and '"))
                {
                    var tableName = e.Message.Between("' and '", '\'');
                    var name = new ResourceManager(typeof(Tables)).GetString(tableName);
                    Message = Messages.UnableToDelete + " "
                              + (string.IsNullOrWhiteSpace(name) ? tableName : name);
                }
                return false;
            }

            return true;
        }

        public void Complete(Expression<Func<Notify, bool>> expression)
        {
            if (expression != null)
                Context.Activities.Add(Activity.New(Context.LoggedInUserId, expression.ToExpressionTarget(),DateTime.Now, ""));

            Complete();
        }
        public void Complete(Expression<Func<Notify, bool>> expression, string description)
        {
            if (expression != null)
                Context.Activities.Add(Activity.New(Context.LoggedInUserId, expression.ToExpressionTarget(), DateTime.Now, description));

            Complete();
        }

        
        public bool TryComplete(Expression<Func<Notify, bool>> expression)
        {
            if (expression != null)
            {
                Context.Activities.Add(Activity.New(Context.LoggedInUserId, expression.ToExpressionTarget(), DateTime.Now.Date, ""));

            }


            return TryComplete();
        }
        public bool TryComplete(Expression<Func<Notify, bool>> expression, string description)
        {
            if (expression != null)
            {
                Context.Activities.Add(Activity.New(Context.LoggedInUserId, expression.ToExpressionTarget(), DateTime.Now.Date, description));

            }


            return TryComplete();
        }

        public void Complete()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        
        public bool BackUp(string path)
        {
            var cn = new SqlConnection(_appConfig.ConnectionString);

            if (cn.State != ConnectionState.Open)
                cn.Open();

            if (string.IsNullOrWhiteSpace(path))
            {
                const string folder = @"D:\" + nameof(MFMinistry) + "BackUp";

                Directory.CreateDirectory(folder);

                path = folder + @"\A" + DateTime.Now.ToString("yyMMddHHmmss") + ".bak";
            }

            var cmd = new SqlCommand
            {
                CommandText = @"BACKUP DATABASE " + _appConfig.DbName
                              + @" TO DISK = '" + path + "'",
                CommandType = CommandType.Text,
                Connection = cn
            };

            cmd.ExecuteReader();
            cn.Close();
            return true;
        }

        public bool Restore(string location)
        {
            try
            {
                var con = new SqlConnection(_appConfig.ConnectionString);

                if (con.State != ConnectionState.Open)
                    con.Open();

                var sqlStmt2 = "ALTER DATABASE " + _appConfig.DbName + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                var bu2 = new SqlCommand(sqlStmt2, con);
                bu2.ExecuteNonQuery();

                var sqlStmt3 = "USE MASTER RESTORE DATABASE  " + _appConfig.DbName + " FROM DISK= '" + location + "' WITH REPLACE;";
                var bu3 = new SqlCommand(sqlStmt3, con);
                bu3.ExecuteNonQuery();

                var sqlStmt4 = "ALTER DATABASE  " + _appConfig.DbName + " SET MULTI_USER";
                var bu4 = new SqlCommand(sqlStmt4, con);
                bu4.ExecuteNonQuery();

                con.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }


        /// <summary>
        ///  please initialize these properties like in Accounting ...
        /// </summary>
        public string Message { get; private set; }

        public IActivityRepository Activities
        {
            get
            {
                if (_activities != null)
                    return _activities;

                _activities = new ActivityRepository(Context);
                return _activities;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (_users != null)
                    return _users;

                _users = new UserRepository(Context);
                return _users;
            }
        }

        public IUserGroupRepository UserGroups
        {
            get
            {
                if (_userGroups != null)
                    return _userGroups;

                _userGroups = new UserGroupRepository(Context);
                return _userGroups;
            }
        }

        public ISettingRepository Settings
        {
            get
            {
                if (_settings != null)
                    return _settings;

                _settings = new SettingRepository(Context);
                return _settings;
            }
        }
        public IQuestionRepository Questions
        {
            get
            {
                if (_questions != null)
                    return _questions;

                _questions = new QuestionRepository(Context);
                return _questions;
            }
        }

        public IBankRepository Banks
        {
            get
            {
                if (_banks != null)
                    return _banks;

                _banks = new BankRepository(Context);
                return _banks;
            }
        }

        public IBankBranchRepository BankBranches
        {
            get
            {
                if (_bankBranches != null)
                    return _bankBranches;

                _bankBranches = new BankBranchRepository(Context);
                return _bankBranches;
            }
        }

        public ICountryRepository Countries
        {
            get
            {
                if (_countries != null)
                    return _countries;

                _countries = new CountryRepository(Context);
                return _countries;
            }
        }

        public ICityRepository Cities
        {
            get
            {
                if (_cities != null)
                    return _cities;

                _cities = new CityRepository(Context);
                return _cities;
            }
        }

        public ICompanyInfoRepository CompanyInfo
        {
            get
            {
                if (_companyInfo != null)
                    return _companyInfo;

                _companyInfo = new CompanyInfoRepository(Context);
                return _companyInfo;
            }
        }


        public IBranchRepository Branches
        {
            get
            {
                if (_branches != null)
                    return _branches;

                _branches = new BranchRepository(Context);
                return _branches;
            }
        }

        public INationalityRepository Nationalities
        {
            get
            {
                if (_nationalities != null)
                    return _nationalities;

                _nationalities = new NationalityRepository(Context);
                return _nationalities;
            }
        }
        public IGrantRepository Grants
        {
            get
            {
                if (_grants != null)
                    return _grants;

                _grants = new GrantRepository(Context);
                return _grants;
            }
        }
        public IGrantRuleRepository GrantRules
        {
            get
            {
                if (_grantrules != null)
                    return _grantrules;

                _grantrules = new GrantRuleRepository(Context);
                return _grantrules;
            }
        }

        public IFinancialGroupRepository FinancialGroups
        {
            get
            {
                if (_financialGroups != null)
                    return _financialGroups;

                _financialGroups = new FinancialGroupRepository(Context);
                return _financialGroups;
            }
        }

        public IGroupRepository RecipientGroup
        {
            get
            {
                if (_recipientGroup != null)
                    return _recipientGroup;

                _recipientGroup = new GroupRepository(Context);
                return _recipientGroup;
            }
        }
        public IDrawerRepository Drawers
        {
            get
            {
                if (_drawer != null)
                    return _drawer;

                _drawer = new DrawerRepository(Context);
                return _drawer;
            }
        }
        public IDepartmentRepository Departments
        {
            get
            {
                if (_department != null)
                    return _department;

                _department = new DepartmentRepository(Context);
                return _department;
            }
        }
        public IMartyrRepository MartyrForms
        {
            get
            {
                if (_martyrForm != null)
                    return _martyrForm;

                _martyrForm = new MartyrRepository(Context);
                return _martyrForm;
            }
        }

        public IMissingRepository MissingForms
        {
            get
            {
                if (_missingForm != null)
                    return _missingForm;

                _missingForm = new MissingRepository(Context);
                return _missingForm;
            }
        }
    }
}
