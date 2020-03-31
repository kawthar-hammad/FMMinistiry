using Almotkaml.MFMinistry.Abstraction;
using Almotkaml.MFMinistry.Business.Extensions;
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;

namespace Almotkaml.MFMinistry.Business.App_Business.General
{

    public class GrantRuleBusiness : Business, IGrantRuleBusiness
    {

        public GrantRuleBusiness(HrMFMinistry humanResource) : base(humanResource)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.GrantRule && permission;


        //public GrantRuleModel Index()
        //{
        //    if (!HavePermission())
        //        return Null<GrantRuleModel>(RequestState.NoPermission);


        //    var grid = UnitOfWork.GrantRules
        //        .GetAll()
        //        .ToGrid();

        //    return new GrantRuleModel()
        //    {
        //        GrantRuleGrid = grid,
        //        CanCreate = ApplicationUser.Permissions.GrantRule_Create,
        //        CanEdit = ApplicationUser.Permissions.GrantRule_Edit,
        //        CanDelete = ApplicationUser.Permissions.GrantRule_Delete,
        //        Grantees = new Grantees() { },
        //    };
        //}

        public void Refresh(GrantRuleModel model) { }

        public GrantRuleModel Prepare()
        {
            if (!HavePermission(ApplicationUser.Permissions.GrantRule_Create))
                return Null<GrantRuleModel>(RequestState.NoPermission);

            var grid = UnitOfWork.GrantRules
                .GetAll()
                .ToGrid();

            return new GrantRuleModel()
            {
                CanCreate = ApplicationUser.Permissions.GrantRule_Edit,
                Grantees = new Grantees(),
                GrantRuleGrid = grid,
                //Grants = new Grantees() { },
            };
        }

        public bool Create(GrantRuleModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.GrantRule_Create))
                return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var _grant = Grant.New(model.GrantName);
            UnitOfWork.Grants.Add(_grant);
            UnitOfWork.Complete();

            var GrantRules = GrantRule.New(_grant.GrantId, new Grantees());
            UnitOfWork.GrantRules.Add(GrantRules);

            UnitOfWork.Complete(n => n.GrantRule_Create);

            return SuccessCreate();
        }

        public GrantRuleModel Find(int id)
        {
            if (!HavePermission())
                return Null<GrantRuleModel>(RequestState.NoPermission);

            if (id <= 0)
                return Null<GrantRuleModel>(RequestState.BadRequest);

            var GrantRule = UnitOfWork.GrantRules.Find(id);

            if (GrantRule == null)
                return Null<GrantRuleModel>(RequestState.NotFound);

            return new GrantRuleModel()
            {
                //GrantId = GrantRule.GrantId,
                Grantees = GrantRule.grantees,
                CanCreate = ApplicationUser.Permissions.GrantRule_Edit
            };
        }

        public bool Edit(GrantRuleModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.GrantRule_Edit))
                return Fail(RequestState.NoPermission);

            if (model.GrantRuleGrid == null)
                return Fail(RequestState.BadRequest);

            foreach (GrantRuleGridRow row in model.GrantRuleGrid)
            {
                var _rule = UnitOfWork.GrantRules.Find(row.GrantRulesId);
                _rule.Modify(row.GrantId, row.Grantees);
                UnitOfWork.Complete(n => n.GrantRule_Edit);

            }
            //if (model.GrantId <= 0)
            //    return Fail(RequestState.BadRequest);

            //if (!ModelState.IsValid(model))
            //    return false;           


            //  var GrantRule = UnitOfWork.GrantRules.Find(model.GrantId);

            //if (GrantRule == null)
            //    return Fail(RequestState.NotFound);

            //GrantRule.Modify(model.GrantId, model.Grantees);


            return SuccessEdit();
        }

        public bool Delete(GrantRuleModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.GrantRule_Delete))
                return Fail(RequestState.NoPermission);

            if (model.GrantId <= 0)
                return Fail(RequestState.BadRequest);

            var GrantRule = UnitOfWork.GrantRules.Find(model.GrantId);

            if (GrantRule == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.GrantRules.Remove(GrantRule);

            if (!UnitOfWork.TryComplete(n => n.GrantRule_Delete))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }

        public bool Select(GrantRuleModel model)
        {
            if (!HavePermission(ApplicationUser.Permissions.Country_Edit))
                return Fail(RequestState.NoPermission);
            if (model.GrantId <= 0)
                return Fail(RequestState.BadRequest);

            var country = UnitOfWork.Countries.Find(model.GrantId);

            if (country == null)
                return Fail(RequestState.NotFound);

            model.GrantName = country.Name;
            return true;

        }

    }
}
