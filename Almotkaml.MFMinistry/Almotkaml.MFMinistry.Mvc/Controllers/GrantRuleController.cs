using Almotkaml.MFMinistry.Business;
using Almotkaml.MFMinistry.Models;
using System.Linq;
using System.Web.Mvc;

namespace Almotkaml.MFMinistry.Mvc.Controllers
{
    public class GrantRuleController : BaseController
    {
        // GET: GrantRule
        public ActionResult Index()
        {
            var model = HrMFMinistry.GrantRule.Prepare();

            if (model == null)
                return HrMFMinistryState();

            SaveModel(model);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(GrantRuleModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HrMFMinistry.GrantRule.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(GrantRuleModel model, FormCollection form)
        {
            var editRuleId = IntValue(form["editCountryId"]);
            var deleteRuleId = IntValue(form["deleteCountryId"]);
            var save = form["save"];
            //// Select
            //if (editRuleId > 0)
            //    return Select(model, editRuleId);

            //// Delete
            //if (deleteRuleId > 0)
            //    return Delete(model, deleteRuleId);

            //Modify
            if (save != null)
            {
                if (!HrMFMinistry.GrantRule.Edit(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }
            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.GrantId == 0)
            {
                if (!HrMFMinistry.GrantRule.Create(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            if (model.GrantId > 0)
            {
                if (!HrMFMinistry.GrantRule.Edit(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(GrantRuleModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<GrantRuleModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
           // model.GrantRuleGrid = loadedModel.GrantRuleGrid;
            model.GrantRuleGrid = loadedModel.GrantRuleGrid
               .Select(l => new GrantRuleGridRow()
               {
                   GrantName = l.GrantName,
                   GrantRulesId = l.GrantRulesId,
                   GrantId=l.GrantId,
                   Grantees = model.GrantRuleGrid.FirstOrDefault(m => m.GrantRulesId == l.GrantRulesId)?.Grantees,//? false
               })
               .ToList();
        }
    }
}
