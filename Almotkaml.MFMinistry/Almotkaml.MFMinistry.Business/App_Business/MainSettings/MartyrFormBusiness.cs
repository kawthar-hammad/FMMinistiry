using Almotkaml.HR.Business.Extensions;
using Almotkaml.MFMinistry.Abstraction;
using Almotkaml.MFMinistry.Business.Extensions;
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;

namespace Almotkaml.MFMinistry.Business.App_Business.MainSettings
{
    public class MartyrFormBusiness : Business, IMartyrFormBusiness
    {
        public MartyrFormBusiness(HrMFMinistry mfMinistry)
            : base(mfMinistry)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Bank && permission;
        //private bool HavePermission(bool permission = true)
        //   => ApplicationUser.Permissions.UserGroup && permission;


        public MartyrFormModel Index()
        {
            if (!HavePermission())
                return Null<MartyrFormModel>(RequestState.NoPermission);


            var grid = UnitOfWork.MartyrForms
                .GetAll()
                .ToGrid();

            return new MartyrFormModel()
            {
                
                CanCreate = ApplicationUser.Permissions.MartyrForm_Create,
                CanEdit = ApplicationUser.Permissions.MartyrForm_Edit,
                CanDelete = ApplicationUser.Permissions.MartyrForm_Delete,
                MartyrFormGrid=grid,
            };
        }

        public void Refresh(MartyrFormModel model) { }

        public MartyrFormModel Prepare()
        {
            //if (!HavePermission(ApplicationUser.Permissions.UserGroup_Create))
            //    return Null<UserGroupFormModel>(RequestState.NoPermission);

            return new MartyrFormModel()
            {
                CanCreate = ApplicationUser.Permissions.MartyrForm_Create,
                CanEdit = ApplicationUser.Permissions.MartyrForm_Edit,
                CanDelete = ApplicationUser.Permissions.MartyrForm_Delete,
                DepartmentList = UnitOfWork.Departments.GetAll().ToList(),
                DrawerList=UnitOfWork.Drawers.GetAll().ToList(),
                FinancialGroupList=UnitOfWork.FinancialGroups.GetAll().ToList(),
                GroupList=UnitOfWork.RecipientGroup.GetAll().ToList(),
            };
        }

        public bool Create(MartyrFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.MartyrForm_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            //if (UnitOfWork.UserGroups.NameIsExisted(model.Name))
            //    return NameExisted(m => model.Name);

            var _formsMFM = FormsMFM.New(model.FormNumber.ToString(),model.FormsType,model.FormCategory,FormsStatus.Martyr,model.DepartmentId,model.DrawerId,model.FinancialGroupId,model.RecipientGroupId);

            UnitOfWork.MartyrForms.Add(_formsMFM);
            UnitOfWork.Complete(n => n.MartyrForm_Create, "قام يإضافة " + model.FormNumber);

            return SuccessCreate();
        }

        public MartyrFormModel Find(int id)
        {
            //if (!HavePermission())
            //    return Null<UserGroupFormModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<MartyrFormModel>(RequestState.BadRequest);

            var _martyrForms = UnitOfWork.MartyrForms.Find(id);

            if (_martyrForms == null)
                return Null<MartyrFormModel>(RequestState.NotFound);

            return new MartyrFormModel()
            {
                RecipientGroupId=_martyrForms.RecipientGroupId,
                DepartmentId=_martyrForms.DepartmentId,
                DrawerId=_martyrForms.DrawerId,
                FinancialGroupId=_martyrForms.FinancialGroupId,
                FormCategory=_martyrForms.FCategory,
                FormsStatus=_martyrForms.FStatus,
                MartyrFormId=_martyrForms.FormsMFMId,
                FormsType=_martyrForms.Type,
                FormNumber=_martyrForms.FormNumber,
                CanCreate = ApplicationUser.Permissions.MartyrForm_Create,
                CanEdit = ApplicationUser.Permissions.MartyrForm_Edit,
                CanDelete = ApplicationUser.Permissions.MartyrForm_Delete,
                DepartmentList = UnitOfWork.Departments.GetAll().ToList(),
                DrawerList = UnitOfWork.Drawers.GetAll().ToList(),
                FinancialGroupList = UnitOfWork.FinancialGroups.GetAll().ToList(),
                GroupList=UnitOfWork.RecipientGroup.GetAll().ToList(),
            };
        }

        public bool Edit(int id, MartyrFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.MartyrForm_Edit))
                return Fail(RequestState.NoPermission);

            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!ModelState.IsValid(model))
                return false;

            //if (UnitOfWork.UserGroups.NameIsExisted(model.Name, id))
            //    return NameExisted(m => model.Name);


            var _martyrForms = UnitOfWork.MartyrForms.Find(id);

            if (_martyrForms == null)
                return Fail(RequestState.NotFound);

            var modifier = _martyrForms.DataCollections.Modify();
                

            modifier.Confirm();


            UnitOfWork.Complete(n => n.MartyrForm_Edit, " قام بالتعديل من " + model.FormNumber + " إلى " + model.FormNumber);

            return SuccessEdit();
        }

        public bool Delete(int id, MartyrFormModel model)
        {
            //if (!HavePermission(ApplicationUser.Permissions.UserGroup_Delete))
            //    return Fail(RequestState.NoPermission);

            if (id <= 0)
                return Fail(RequestState.BadRequest);

            var userGroup = UnitOfWork.UserGroups.Find(id);

            if (userGroup == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.UserGroups.Remove(userGroup);

            if (!UnitOfWork.TryComplete(n => n.UserGroup_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}