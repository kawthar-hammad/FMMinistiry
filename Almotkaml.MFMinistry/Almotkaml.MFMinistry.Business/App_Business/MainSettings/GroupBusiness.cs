using Almotkaml.MFMinistry.Abstraction;
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;
using System.Linq;

namespace Almotkaml.MFMinistry.Business.App_Business.MainSettings
{
    public class GroupBusiness : Business, IGroupBusiness
    {
        public GroupBusiness(HrMFMinistry mfMinistry)
            : base(mfMinistry)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.RecipientGroup && permission;




        public GroupModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.RecipientGroup_Create))
                return Null<GroupModel>(RequestState.NoPermission);

            return new GroupModel()
            {
                CanCreate = ApplicationUser.Permissions.RecipientGroup_Create,
                CanEdit = ApplicationUser.Permissions.RecipientGroup_Edit,
                CanDelete = ApplicationUser.Permissions.RecipientGroup_Delete,
               // GroupList = UnitOfWork.Groups.GetAll().ToList(),
                GroupGrid = UnitOfWork.RecipientGroup
                .GetAll()
                    .Select(a => new GroupGridRow()
                    {
                        RecipientGroupId = a.RecipientGroupId,
                        GroupName = a.GroupName,
                        GroupNumber = a.GroupNumber
                    }),

            };
        }

        public void Refresh(GroupModel model)
        {

        }

        public bool Select(GroupModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.RecipientGroup_Edit))
                return Fail(RequestState.NoPermission);
            if (model.RecipientGroupId <= 0)
                return Fail(RequestState.BadRequest);

            var Group = UnitOfWork.RecipientGroup.Find(model.RecipientGroupId);

            if (Group == null)
                return Fail(RequestState.NotFound);
            model.RecipientGroupId = Group.RecipientGroupId;
            model.GroupName = Group.GroupName;
            model.GroupNumber = Group.GroupNumber;
            return true;
        }

        public bool Create(GroupModel model)
        {

            if (!HavePermission(ApplicationUser.Permissions.RecipientGroup_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.RecipientGroup.NameIsExisted(model.GroupName))
                return NameExisted();

            var Group = RecipientGroup.New(model.GroupName, model.GroupNumber);
            UnitOfWork.RecipientGroup.Add(Group);

            //UnitOfWork.Complete(n => n.Group_Create);
            UnitOfWork.Complete(n => n.RecipientGroup_Create, "قام يإضافة "+ model.GroupName);

            return SuccessCreate();
        }

        public bool Edit(GroupModel model)
        {
            if (model.RecipientGroupId <= 0)
                return Fail(RequestState.BadRequest);

            if (!HavePermission(ApplicationUser.Permissions.RecipientGroup_Edit))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var Group = UnitOfWork.RecipientGroup.Find(model.RecipientGroupId);
            var GroupName = Group.GroupName;
            if (Group == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.RecipientGroup.NameIsExisted(model.GroupName))
                return NameExisted();
            Group.Modify(model.GroupName, model.GroupNumber);

            //UnitOfWork.Complete(n => n.Group_Edit);
            UnitOfWork.Complete(n => n.RecipientGroup_Edit, " قام بالتعديل من " + GroupName + " إلى " + model.GroupName);
            return SuccessEdit();
        }

        public bool Delete(GroupModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.RecipientGroup_Delete))
                return Fail(RequestState.NoPermission);

            if (model.RecipientGroupId <= 0)
                return Fail(RequestState.BadRequest);

            var Group = UnitOfWork.RecipientGroup.Find(model.RecipientGroupId);

            if (Group == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.RecipientGroup.Remove(Group);

            //if (!UnitOfWork.TryComplete(n => n.Group_Delete))
            //    return Fail(UnitOfWork.Message);
           
            if (!UnitOfWork.TryComplete(n => n.RecipientGroup_Delete, "قام بحذف " + Group.GroupName))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}