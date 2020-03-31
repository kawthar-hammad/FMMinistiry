using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using Almotkaml.MFMinistry.Repository;


namespace Almotkaml.MFMinistry.Business
{
    public abstract class Business : Business<HrMFMinistry, LoginModel, IUnitOfWork, ApplicationManager, User, ApplicationUser, IApplicationUser, ISettings, Permission, ICompanyInfo>
    {
        private readonly HrMFMinistry _mfMinistry;

        public Business(HrMFMinistry mfMinistry) : base(mfMinistry)
        {
            _mfMinistry = mfMinistry;
        }

        //protected IErpUnitOfWork ErpUnitOfWork => _mfMinistry.ErpUnitOfWork;

    }
}