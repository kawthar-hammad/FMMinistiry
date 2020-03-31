using Almotkaml.MFMinistry.Business.App_Business.MainSettings;
using Almotkaml.MFMinistry.Abstraction;
using Almotkaml.MFMinistry.Business.App_Business.General;
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using Almotkaml.MFMinistry.Repository;

namespace Almotkaml.MFMinistry.Business
{
    public class HrMFMinistry : Application<LoginModel, IUnitOfWork, ApplicationManager, User, ApplicationUser, IApplicationUser, ISettings, Permission, ICompanyInfo>
        , IHrMFMinistry
    {

        private readonly AppConfig _erAppConfig;

        private IBankBusiness _bank;
        private IBankBranchBusiness _bankBranch;
        private ICountryBusiness _country;
        private ICityBusiness _city;
        private IQuestionBusiness _question;
        private ISettingsBusiness _setting;
        private ICompanyInfoBusiness _companyInfo;
        private IHomeBusiness _home;
        private IBackUpRestoreBusiness _backUpRestore;
        private IUserActivityBusiness _userActivity;
        private IUserBusiness _user;
        private IUserGroupBusiness _userGroup;
        private IBranchBusiness _branch;
        private IAccountBusiness _account;
        private INationalityBusiness _nationality;
        private IGrantRuleBusiness _GrantRule;
        private IFinancialGroupBusiness _FinancialGroup;
        private IGroupBusiness _recipientGroup;
        private IMartyrFormBusiness _Martyr;
        private IDrawerBusiness _Drawer;
        private IDepartmentBusiness _Department;
        private IMissingFormBusiness _MissingForm;
        public HrMFMinistry(StartUp<LoginModel> startUp, AppConfig erAppConfig) : base(startUp)
        {
            Check.NotNull(erAppConfig, nameof(erAppConfig));
            _erAppConfig = erAppConfig;
        }

        public HrMFMinistry(StartUp<IApplicationUser, ISettings, ICompanyInfo> startUp, AppConfig erAppConfig) : base(startUp)
        {
            Check.NotNull(erAppConfig, nameof(erAppConfig));
            _erAppConfig = erAppConfig;
        }

        //public override void Dispose()
        //{
        //    _erpUnitOfWork?.Dispose();
        //    base.Dispose();
        //}

        //public IErpUnitOfWork ErpUnitOfWork
        //{
        //    get
        //    {
        //        if (_erpUnitOfWork != null)
        //            return _erpUnitOfWork;

        //        _erpUnitOfWork = ObjectCreator.Create<IErpUnitOfWork>(_erAppConfig.RepositoryType, _erAppConfig, 0);
        //        return _erpUnitOfWork;
        //    }
        //}

        public IAccountBusiness Account
        {
            get
            {
                if (_account != null)
                    return _account;

                _account = new AccountBusiness(this);
                return _account;
            }
        }



        public IUserBusiness User
        {
            get
            {
                if (_user != null)
                    return _user;

                _user = new UserBusiness(this);
                return _user;
            }
        }

        public IUserGroupBusiness UserGroup
        {
            get
            {
                if (_userGroup != null)
                    return _userGroup;

                _userGroup = new UserGroupBusiness(this);
                return _userGroup;
            }
        }
        public IGrantRuleBusiness GrantRule
        {
            get
            {
                if (_GrantRule != null)
                    return _GrantRule;

                _GrantRule = new GrantRuleBusiness(this);
                return _GrantRule;
            }
        }

        public IBranchBusiness Branch
        {
            get
            {
                if (_branch != null)
                    return _branch;

                _branch = new BranchBusiness(this);
                return _branch;
            }
        }


        public INationalityBusiness Nationality
        {
            get
            {
                if (_nationality != null)
                    return _nationality;

                _nationality = new NationalityBusiness(this);
                return _nationality;
            }
        }

     
        
        public IBankBusiness Bank
        {
            get
            {
                if (_bank != null)
                    return _bank;

                _bank = new BankBusiness(this);
                return _bank;
            }
        }


        public IBankBranchBusiness BankBranch
        {
            get
            {
                if (_bankBranch != null)
                    return _bankBranch;

                _bankBranch = new BankBranchBusiness(this);
                return _bankBranch;
            }
        }

        public ICountryBusiness Country
        {
            get
            {
                if (_country != null)
                    return _country;

                _country = new CountryBusiness(this);
                return _country;
            }
        }


        public ICityBusiness City
        {
            get
            {
                if (_city != null)
                    return _city;

                _city = new CityBusiness(this);
                return _city;
            }
        }


     
        public ISettingsBusiness Setting
        {
            get
            {
                if (_setting != null)
                    return _setting;

                _setting = new SettingsBusiness(this);
                return _setting;
            }
        }

        public IQuestionBusiness Question
        {
            get
            {
                if (_question != null)
                    return _question;

                _question = new QuestionBusiness(this);
                return _question;
            }
        }


        public ICompanyInfoBusiness CompanyInfo
        {
            get
            {
                if (_companyInfo != null)
                    return _companyInfo;

                _companyInfo = new CompanyInfoBusiness(this);
                return _companyInfo;
            }
        }


        public IHomeBusiness Home
        {
            get
            {
                if (_home != null)
                    return _home;

                _home = new HomeBusiness(this);
                return _home;
            }
        }


         public IUserActivityBusiness UserActivity
        {
            get
            {
                if (_userActivity != null)
                    return _userActivity;

                _userActivity = new UserActivityBusiness(this);
                return _userActivity;
            }
        }

        public IBackUpRestoreBusiness BackUpRestore
        {
            get
            {
                if (_backUpRestore != null)
                    return _backUpRestore;

                _backUpRestore = new BackUpRestoreBusiness(this);
                return _backUpRestore;
            }
        }
        public IFinancialGroupBusiness FinancialGroup
        {
            get
            {
                if (_FinancialGroup != null)
                    return _FinancialGroup;

                _FinancialGroup = new FinancialGroupBusiness(this);
                return _FinancialGroup;
            }
        }
        public IMartyrFormBusiness MartyrForm
        {
            get
            {
                if (_Martyr != null)
                    return _Martyr;

                _Martyr = new MartyrFormBusiness(this);
                return _Martyr;
            }
        }

        public IGroupBusiness RecipientGroup
        {
            get
            {
                if (_recipientGroup != null)
                    return _recipientGroup;

                _recipientGroup = new GroupBusiness(this);
                return _recipientGroup;
            }
        }
        public IDrawerBusiness Drawer
        {
            get
            {
                if (_Drawer != null)
                    return _Drawer;
                
                _Drawer = new DrawerBusiness(this);
                return _Drawer;
            }
        }
        public IDepartmentBusiness Department
        {
            get
            {
                if (_Department != null)
                    return _Department;

                _Department = new DepartmentBusiness(this);
                return _Department;
            }
        }

        public IMissingFormBusiness MissingForm
        {
            get
            {
                if (_MissingForm != null)
                    return _MissingForm;

                _MissingForm = new MissingFormBusiness(this);
                return _MissingForm;
            }
        }


    }
}
