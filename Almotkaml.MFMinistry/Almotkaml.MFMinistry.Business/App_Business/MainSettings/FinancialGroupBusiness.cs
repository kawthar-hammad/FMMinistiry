using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using Almotkaml.MFMinistry.Business.Extensions;
using System.Linq;
using Almotkaml.MFMinistry.Abstraction;

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
                FinancialGroupGrid = UnitOfWork.FinancialGroups.GetAll().ToGrid()
                   
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

            var financialGroups = UnitOfWork.FinancialGroups.Find(model.FinancialGroupId);

            if (financialGroups == null)
                return Fail(RequestState.NotFound);

            model.Name = financialGroups.Name;
            model.FinancialGroupNO = financialGroups.Number;
            return true;

        }

        public bool Create(FinancialGroupModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.FinancialGroup_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.FinancialGroups.NameIsExisted(model.Name))
                return NameExisted();
            var financialGroups = FinancialGroup.New(model.Name,model.FinancialGroupNO);
            UnitOfWork.FinancialGroups.Add(financialGroups);

            //UnitOfWork.Complete(n => n.FinancialGroup_Create);
            UnitOfWork.Complete(n => n.FinancialGroup_Create, "قام بإضافة " + model.Name +"-"+ model.FinancialGroupNO);

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

            var financialGroup = UnitOfWork.FinancialGroups.Find(model.FinancialGroupId);
            var fGName = financialGroup.Name;
            if (financialGroup == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.FinancialGroups.NameIsExisted(model.Name, model.FinancialGroupId))
                return NameExisted();
            financialGroup.Modify(model.Name,model.FinancialGroupNO);

            //UnitOfWork.Complete(n => n.FinancialGroup_Edit);
            //UnitOfWork.Complete(n => n.FinancialGroup_Edit, "قام بتعديل " + model.Name + "-" + model.FinancialGroupNO);
            UnitOfWork.Complete(n => n.FinancialGroup_Edit, " قام بالتعديل من " + fGName + " إلى " + model.Name);

            return SuccessEdit();
        }

        public bool Delete(FinancialGroupModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.FinancialGroup_Delete))
                return Fail(RequestState.NoPermission);

            if (model.FinancialGroupId <= 0)
                return Fail(RequestState.BadRequest);

            var financialGroup = UnitOfWork.FinancialGroups.Find(model.FinancialGroupId);

            if (financialGroup == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.FinancialGroups.Remove(financialGroup);

            if (!UnitOfWork.TryComplete(n => n.FinancialGroup_Delete, "قام بحذف " + financialGroup.Name))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

    }
}