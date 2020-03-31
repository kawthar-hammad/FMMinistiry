using Almotkaml.MFMinistry.Abstraction;
using Almotkaml.MFMinistry.Business.Extensions;
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;

namespace Almotkaml.MFMinistry.Business.App_Business.MainSettings
{
    public class DrawerBusiness : Business, IDrawerBusiness
    {
        public DrawerBusiness(HrMFMinistry mfMinistry)
            : base(mfMinistry)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Drawer && permission;


        public DrawerModel Prepare()
        {

            if (!HavePermission(ApplicationUser.Permissions.Drawer_Create))
                return Null<DrawerModel>(RequestState.NoPermission);

            return new DrawerModel()
            {
                CanCreate = ApplicationUser.Permissions.Drawer_Create,
                CanEdit = ApplicationUser.Permissions.Drawer_Edit,
                CanDelete = ApplicationUser.Permissions.Drawer_Delete,
                DrawerGrid = UnitOfWork.Drawers.GetAll().ToGrid()
            };
        }

        public void Refresh(DrawerModel model)
        {

        }

        public bool Select(DrawerModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.Drawer_Edit))
                return Fail(RequestState.NoPermission);
            if (model.DrawerId <= 0)
                return Fail(RequestState.BadRequest);

            var Drawer = UnitOfWork.Drawers.Find(model.DrawerId);

            if (Drawer == null)
                return Fail(RequestState.NotFound);

            model.DrawerNumber = Drawer.DrawerNumber;
            return true;
        }

        public bool Create(DrawerModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Drawer_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Drawers.NameIsExisted(model.DrawerNumber))
                return NameExisted();
            var drawer = Drawer.New(model.DrawerNumber);
            UnitOfWork.Drawers.Add(drawer);

            UnitOfWork.Complete(n => n.Drawer_Create);

            return SuccessCreate();
        }

        public bool Edit(DrawerModel model)
        {
            if (model.DrawerId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Drawer_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var Drawer = UnitOfWork.Drawers.Find(model.DrawerId);

            if (Drawer == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Drawers.NameIsExisted(model.DrawerNumber, model.DrawerId))
                return NameExisted();
            Drawer.Modify(model.DrawerNumber);

            UnitOfWork.Complete(n => n.Drawer_Edit);

            return SuccessEdit();
        }

        public bool Delete(DrawerModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Drawer_Delete))
                return Fail(RequestState.NoPermission);

            if (model.DrawerId <= 0)
                return Fail(RequestState.BadRequest);

            var Drawer = UnitOfWork.Drawers.Find(model.DrawerId);

            if (Drawer == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Drawers.Remove(Drawer);
            if (!UnitOfWork.TryComplete(n => n.Drawer_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}