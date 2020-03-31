using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using Almotkaml.MFMinistry.Repository;

namespace Almotkaml.MFMinistry.Business
{
    public class ApplicationManager : ApplicationManager<LoginModel, User, IUnitOfWork, ISettings, ICompanyInfo>
    {
        public override User LoginStart(LoginModel model)
            => UnitOfWork.Users.GetByNameAndPassword(model.UserName, model.Password);

        public override ISettings GetSettings()
            => UnitOfWork.Settings.Load();

        public override ICompanyInfo GetCompanyInfo()
            => UnitOfWork.CompanyInfo.Load();

        public override string ExtraCheck(LoginModel model, User user)
        {
            return null;
        }
    }
}