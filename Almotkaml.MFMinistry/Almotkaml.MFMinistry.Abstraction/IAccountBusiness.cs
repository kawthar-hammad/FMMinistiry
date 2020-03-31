using Almotkaml.Business;
using Almotkaml.MFMinistry.Models;

namespace Almotkaml.MFMinistry.Abstraction
{
    public interface IAccountBusiness : IDefaultAccount<LoginModel, ProfileModel, NotificationModel>
    {
    }
}