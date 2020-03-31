using Almotkaml;

namespace Almotkaml.MFMinistry.Abstraction
{
    public interface IHrMFMinistry : IApplication<IApplicationUser, ISettings, ICompanyInfo, Permission>
    {
        IUserActivityBusiness UserActivity { get; }
        IAccountBusiness Account { get; }
        IUserBusiness User { get; }
        IUserGroupBusiness UserGroup { get; }
        IQuestionBusiness Question { get; }
        IBankBusiness Bank { get; }
        IBankBranchBusiness BankBranch { get; }
        IBranchBusiness Branch { get; }
        ICountryBusiness Country { get; }
        ICityBusiness City { get; }
    
        ISettingsBusiness Setting { get; }
     
        ICompanyInfoBusiness CompanyInfo { get; }
        IHomeBusiness Home { get; }
        IBackUpRestoreBusiness BackUpRestore { get; }
        INationalityBusiness Nationality { get; }
        IGrantRuleBusiness GrantRule { get; }
        IFinancialGroupBusiness FinancialGroup { get; }
        IMartyrFormBusiness MartyrForm { get; }
        IGroupBusiness RecipientGroup { get; }
        IDrawerBusiness Drawer { get; }
        IDepartmentBusiness Department { get; }
        IMissingFormBusiness MissingForm { get; }
    }
}