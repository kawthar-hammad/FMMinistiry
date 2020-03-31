using Almotkaml.HR.Business.Extensions;
using Almotkaml.MFMinistry.Abstraction;
using Almotkaml.MFMinistry.Business.Extensions;
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;

namespace Almotkaml.MFMinistry.Business.App_Business.MainSettings
{
    public class DepartmentBusiness : Business, IDepartmentBusiness
    {
        public DepartmentBusiness(HrMFMinistry mfMinistry)
            : base(mfMinistry)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.Department && permission;


        public DepartmentModel Prepare()
        {

            if (!HavePermission(ApplicationUser.Permissions.Department_Create))
                return Null<DepartmentModel>(RequestState.NoPermission);

            return new DepartmentModel()
            {
                CanCreate = ApplicationUser.Permissions.Department_Create,
                CanEdit = ApplicationUser.Permissions.Department_Edit,
                CanDelete = ApplicationUser.Permissions.Department_Delete,
                BranchList = UnitOfWork.Branches.GetAll().ToList(),
                DepartmentGrid = UnitOfWork.Departments.GetDepartmentWithBranch().ToGrid(),
            };
        }

        public void Refresh(DepartmentModel model)
        {

        }

        public bool Select(DepartmentModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.Department_Edit))
                return Fail(RequestState.NoPermission);
            if (model.DepartmentId <= 0)
                return Fail(RequestState.BadRequest);

            var Department = UnitOfWork.Departments.Find(model.DepartmentId);

            if (Department == null)
                return Fail(RequestState.NotFound);

            model.DepartmentName = Department.Departmentname;
            return true;
        }

        public bool Create(DepartmentModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Department_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            //if (UnitOfWork.BankBranches.DepartmentExisted(model.DepartmentName, model.BranchId, model.DepartmentId))
            //    return NameExisted();
            var department = Department.New(model.DepartmentName, model.BranchId);
            UnitOfWork.Departments.Add(department);

            UnitOfWork.Complete(n => n.Department_Create);

            return SuccessCreate();
        }

        public bool Edit(DepartmentModel model)
        {
            if (model.DepartmentId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.Department_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var Department = UnitOfWork.Departments.Find(model.DepartmentId);

            if (Department == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Departments.DepartmentExisted(model.DepartmentName, model.DepartmentId))
                return NameExisted();
            Department.Modify(model.DepartmentName,model.BranchId);

            UnitOfWork.Complete(n => n.Department_Edit);

            return SuccessEdit();
        }

        public bool Delete(DepartmentModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Department_Delete))
                return Fail(RequestState.NoPermission);

            if (model.DepartmentId <= 0)
                return Fail(RequestState.BadRequest);

            var Department = UnitOfWork.Departments.Find(model.DepartmentId);

            if (Department == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Departments.Remove(Department);
            if (!UnitOfWork.TryComplete(n => n.Department_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}