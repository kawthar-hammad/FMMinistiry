using Almotkaml.MFMinistry.Models;
using System.Web.Mvc;

namespace Almotkaml.MFMinistry.Mvc.Controllers
{
    public class BranchController : BaseController
    {
        // GET: CostCenter
        public ActionResult Index()
        {
            var model = HrMFMinistry.Branch.Prepare();

            if (model == null)
                return HrMFMinistryState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BranchModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HrMFMinistry.Branch.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(BranchModel model, FormCollection form)
        {
            var editBranchId = IntValue(form["editBranchId"]);
            var deleteBranchId = IntValue(form["deleteBranchId"]);

            // Select
            if (editBranchId > 0)
                return Select(model, editBranchId);

            // Delete
            if (deleteBranchId > 0)
                return Delete(model, deleteBranchId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.BranchId == 0)
            {
                if (!HrMFMinistry.Branch.Create(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            if (model.BranchId > 0)
            {
                if (!HrMFMinistry.Branch.Edit(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(BranchModel model, int editBranchId)
        {
            ModelState.Clear();
            model.BranchId = editBranchId;

            if (!HrMFMinistry.Branch.Select(model))
                return AjaxHrMFMinistrytate("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(BranchModel model, int deleteBranchId)
        {
            ModelState.Clear();
            model.BranchId = deleteBranchId;

            if (!HrMFMinistry.Branch.Delete(model))
                return AjaxHrMFMinistrytate("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(BranchModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<BranchModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.BranchGrid = loadedModel.BranchGrid;
        }
    }
}