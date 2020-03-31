using Almotkaml.MFMinistry.Models;
using System.Web.Mvc;

namespace Almotkaml.MFMinistry.Mvc.Controllers
{
    public class RecipientGroupController : BaseController
    {
        // GET: CostCenter
        public ActionResult Index()
        {
            var model = HrMFMinistry.RecipientGroup.Prepare();

            if (model == null)
                return HrMFMinistryState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(GroupModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HrMFMinistry.RecipientGroup.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(GroupModel model, FormCollection form)
        {
            var editGroupId = IntValue(form["editRecipientGroupId"]);
            var deleteGroupId = IntValue(form["deleteRecipientGroupId"]);

            // Select
            if (editGroupId > 0)
                return Select(model, editGroupId);

            // Delete
            if (deleteGroupId > 0)
                return Delete(model, deleteGroupId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.RecipientGroupId == 0)
            {
                if (!HrMFMinistry.RecipientGroup.Create(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            if (model.RecipientGroupId > 0)
            {
                if (!HrMFMinistry.RecipientGroup.Edit(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(GroupModel model, int editGroupId)
        {
            ModelState.Clear();
            model.RecipientGroupId = editGroupId;

            if (!HrMFMinistry.RecipientGroup.Select(model))
                return AjaxHrMFMinistrytate("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(GroupModel model, int deleteGroupId)
        {
            ModelState.Clear();
            model.RecipientGroupId = deleteGroupId;

            if (!HrMFMinistry.RecipientGroup.Delete(model))
                return AjaxHrMFMinistrytate("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(GroupModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<GroupModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.GroupGrid = loadedModel.GroupGrid;
        }
    }
}