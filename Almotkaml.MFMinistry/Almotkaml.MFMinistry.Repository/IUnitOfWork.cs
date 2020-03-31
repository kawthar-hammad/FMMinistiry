using Almotkaml.MFMinistry.Repository;
using Almotkaml.Repository;

namespace Almotkaml.MFMinistry.Repository
{
    public interface IUnitOfWork : IDefaultUnitOfWork<Notify>
    {
        IActivityRepository Activities { get; }

        IUserRepository Users { get; }
        IUserGroupRepository UserGroups { get; }
        ISettingRepository Settings { get; }

        INationalityRepository Nationalities { get; }
        IQuestionRepository Questions { get; }
        IBankRepository Banks { get; }
        IBankBranchRepository BankBranches { get; }
        IBranchRepository Branches { get; }
        ICityRepository Cities { get; }
        ICountryRepository Countries { get; }
        ICompanyInfoRepository CompanyInfo { get; }
        IGrantRepository Grants { get; }
        IGrantRuleRepository GrantRules { get; }
        IFinancialGroupRepository FinancialGroups { get; }
        IGroupRepository RecipientGroup { get; }
        IDepartmentRepository Departments { get; }
        IDrawerRepository Drawers { get; }
        IMartyrRepository MartyrForms { get; }
        IMissingRepository MissingForms { get; }
    }
}
