using Almotkaml.MFMinistry.Abstraction;
using Almotkaml.MFMinistry.Business.Extensions;
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;

namespace Almotkaml.MFMinistry.Business.App_Business.MainSettings
{
    public class FinancialGroupBusiness : Business, IFinancialGroupBusiness
    {
        public FinancialGroupBusiness(HrMFMinistry mfMinistry)
            : base(mfMinistry)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.FinancialGroup && permission;




        public FinancialGroupModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.FinancialGroup_Create))
                return Null<FinancialGroupModel>(RequestState.NoPermission);

            return new FinancialGroupModel()
            {
                CanCreate = ApplicationUser.Permissions.FinancialGroup_Create,
                CanEdit = ApplicationUser.Permissions.FinancialGroup_Edit,
                CanDelete = ApplicationUser.Permissions.FinancialGroup_Delete,
                FinancialGroupGrid = UnitOfWork.FinancialGroups.GetAll().ToGrid(),

            };
        }

        public void Refresh(FinancialGroupModel model)
        {

        }

        public bool Select(FinancialGroupModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.FinancialGroup_Edit))
                return Fail(RequestState.NoPermission);
            if (model.FinancialGroupId <= 0)
                return Fail(RequestState.BadRequest);

            var FinancialGroup = UnitOfWork.Cities.Find(model.FinancialGroupId);

            if (FinancialGroup == null)
                return Fail(RequestState.NotFound);
            model.FinancialGroupId = FinancialGroup.CountryId;
            model.Name = FinancialGroup.Name;
            return true;
        }

        public bool Create(FinancialGroupModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.FinancialGroup_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            //if (UnitOfWork.FinancialGroups.FinancialGroupExisted(model.Name, model.CountryId, model.FinancialGroupId))
            //    return NameExisted();

            var _financialGroup = FinancialGroup.New(model.Name, model.FinancialGroupNO);
            UnitOfWork.FinancialGroups.Add(_financialGroup);

            UnitOfWork.Complete(n => n.FinancialGroup_Create);
            UnitOfWork.Complete(n => n.FinancialGroup_Create,"قام يإضافة "+ model.Name);

            return SuccessCreate();
        }

        public bool Edit(FinancialGroupModel model)
        {
            if (model.FinancialGroupId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.FinancialGroup_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var FinancialGroup = UnitOfWork.FinancialGroups.Find(model.FinancialGroupId);
            var FinancialGroupName = FinancialGroup.Name;
            if (FinancialGroup == null)
                return Fail(RequestState.NotFound);

            //if (UnitOfWork.Cities.FinancialGroupExisted(model.Name, model.FinancialGroupNO))
            //    return NameExisted();
            FinancialGroup.Modify(model.Name, model.FinancialGroupNO);

            //UnitOfWork.Complete(n => n.FinancialGroup_Edit);
            UnitOfWork.Complete(n => n.FinancialGroup_Edit, " قام بالتعديل من " + FinancialGroupName + " إلى " + model.Name);
            return SuccessEdit();
        }

        public bool Delete(FinancialGroupModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.FinancialGroup_Delete))
                return Fail(RequestState.NoPermission);

            if (model.FinancialGroupId <= 0)
                return Fail(RequestState.BadRequest);

            var FinancialGroup = UnitOfWork.Cities.Find(model.FinancialGroupId);

            if (FinancialGroup == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Cities.Remove(FinancialGroup);

            //if (!UnitOfWork.TryComplete(n => n.FinancialGroup_Delete))
            //    return Fail(UnitOfWork.Message);
           
            if (!UnitOfWork.TryComplete(n => n.FinancialGroup_Create, "قام يحذف " + FinancialGroup.Name))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}