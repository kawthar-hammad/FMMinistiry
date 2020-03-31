using Almotkaml.Extensions;
using Almotkaml.MFMinistry.Business.Extensions;
using Almotkaml.MFMinistry.Models;
using System;
using Almotkaml.MFMinistry.Abstraction;

namespace Almotkaml.MFMinistry.Business.App_Business.General
{
    public class UserActivityBusiness : Business, IUserActivityBusiness
    {
        public UserActivityBusiness(HrMFMinistry humanResource) : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.UserActivity && permission;

        public UserActivityModel Index()
        {
            if (!HavePermission())
                return Null<UserActivityModel>(RequestState.NoPermission);

            return new UserActivityModel()
            {
                DateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).FormatToString(),
                DateTo = DateTime.Today.FormatToString(),
                UserListItems = UnitOfWork.Users.GetAll().ToList()
            };
        }

        public bool Search(UserActivityModel model)
        {
            if (!HavePermission())
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            model.GridRows = UnitOfWork.Activities
                .GetUserActivities(model.DateFrom.ToDateTime(), model.DateTo.ToDateTime(), model.UserId ?? 0)
                .ToGrid();

            return true;
        }

        public void Refresh(UserActivityModel model)
        {

        }
    }
}
