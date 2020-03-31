using Almotkaml.MFMinistry.Models;

namespace Almotkaml.MFMinistry.Abstraction
{
    public interface IUserActivityBusiness
    {
        UserActivityModel Index();
        bool Search(UserActivityModel model);

        void Refresh(UserActivityModel model);


    }
}
