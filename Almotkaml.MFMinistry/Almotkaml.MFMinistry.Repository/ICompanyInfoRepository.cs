using Almotkaml.MFMinistry.Domain;

namespace Almotkaml.MFMinistry.Repository
{
    public interface ICompanyInfoRepository
    {
        CompanyInfo Load();
        void Save(CompanyInfo companyInfo);
    }
}