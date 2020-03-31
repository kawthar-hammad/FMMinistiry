using Almotkaml.HR.Business.Extensions;
using Almotkaml.MFMinistry.Abstraction;
using Almotkaml.MFMinistry.Business.Extensions;
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;

namespace Almotkaml.MFMinistry.Business.App_Business.MainSettings
{
    public class MissingFormBusiness : Business,IMissingFormBusiness
    {
        public MissingFormBusiness(HrMFMinistry mfMinistry)
            : base(mfMinistry)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Bank && permission;
        //private bool HavePermission(bool permission = true)
        //   => ApplicationUser.Permissions.UserGroup && permission;


        public MissingFormModel Index()
        {
            if (!HavePermission())
                return Null<MissingFormModel>(RequestState.NoPermission);


            var grid = UnitOfWork.MissingForms
                .GetAll()
               .ToMissingGrid();

            return new MissingFormModel()
            {
                
                CanCreate = ApplicationUser.Permissions.MissingForm_Create,
                CanEdit = ApplicationUser.Permissions.MissingForm_Edit,
                CanDelete = ApplicationUser.Permissions.MissingForm_Delete,
                MissingFormGrid = grid,
            };
        }

        public void Refresh(MissingFormModel model) { }

        public MissingFormModel Prepare()
        {
            //if (!HavePermission(ApplicationUser.Permissions.UserGroup_Create))
            //    return Null<UserGroupFormModel>(RequestState.NoPermission);

            return new MissingFormModel()
            {
                CanCreate = ApplicationUser.Permissions.MissingForm_Create,
                CanEdit = ApplicationUser.Permissions.MissingForm_Edit,
                CanDelete = ApplicationUser.Permissions.MissingForm_Delete,
                DepartmentList = UnitOfWork.Departments.GetAll().ToList(),
                DrawerList=UnitOfWork.Drawers.GetAll().ToList(),
                FinancialGroupList=UnitOfWork.FinancialGroups.GetAll().ToList(),
                GroupList=UnitOfWork.RecipientGroup.GetAll().ToList(),
            };
        }

        public bool Create(MissingFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.MissingForm_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            //if (UnitOfWork.UserGroups.NameIsExisted(model.Name))
            //    return NameExisted(m => model.Name);

            var _formsMFM = FormsMFM.New(model.FormNumber.ToString(),model.FormsType,model.FormCategory,FormsStatus.Missing,model.DepartmentId,model.DrawerId,model.FinancialGroupId,model.RecipientGroupId);

            UnitOfWork.MissingForms.Add(_formsMFM);
            UnitOfWork.Complete(n => n.MissingForm_Create, "قام يإضافة " + model.FormNumber);

            return SuccessCreate();
        }

        public MissingFormModel Find(int id)
        {
            //if (!HavePermission())
            //    return Null<UserGroupFormModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<MissingFormModel>(RequestState.BadRequest);

            var _MissingForms = UnitOfWork.MissingForms.Find(id);

            if (_MissingForms == null)
                return Null<MissingFormModel>(RequestState.NotFound);

            return new MissingFormModel()
            {
                RecipientGroupId=_MissingForms.RecipientGroupId,
                DepartmentId=_MissingForms.DepartmentId,
                DrawerId=_MissingForms.DrawerId,
                FinancialGroupId=_MissingForms.FinancialGroupId,
                FormCategory=_MissingForms.FCategory,
                FormsStatus=_MissingForms.FStatus,
                MissingFormId=_MissingForms.FormsMFMId,
                FormsType=_MissingForms.Type,
                FormNumber=_MissingForms.FormNumber,
                CanCreate = ApplicationUser.Permissions.MissingForm_Create,
                CanEdit = ApplicationUser.Permissions.MissingForm_Edit,
                CanDelete = ApplicationUser.Permissions.MissingForm_Delete,
                DepartmentList = UnitOfWork.Departments.GetAll().ToList(),
                DrawerList = UnitOfWork.Drawers.GetAll().ToList(),
                FinancialGroupList = UnitOfWork.FinancialGroups.GetAll().ToList(),
                GroupList=UnitOfWork.RecipientGroup.GetAll().ToList(),
            };
        }

        public bool Edit(int id, MissingFormModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.MissingForm_Edit))
                return Fail(RequestState.NoPermission);

            if (id <= 0)
                return Fail(RequestState.BadRequest);

            if (!ModelState.IsValid(model))
                return false;

            //if (UnitOfWork.UserGroups.NameIsExisted(model.Name, id))
            //    return NameExisted(m => model.Name);


            var _MissingForms = UnitOfWork.MissingForms.Find(id);

            if (_MissingForms == null)
                return Fail(RequestState.NotFound);

            var modifier = _MissingForms.DataCollections.Modify();
                

            modifier.Confirm();


            UnitOfWork.Complete(n => n.MissingForm_Edit, " قام بالتعديل من " + model.FormNumber + " إلى " + model.FormNumber);

            return SuccessEdit();
        }

        public bool Delete(int id, MissingFormModel model)
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