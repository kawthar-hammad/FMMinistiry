using Almotkaml.MFMinistry.Models;
using System.Web.Mvc;

namespace Almotkaml.MFMinistry.Mvc.Controllers
{
    public class DrawerController : BaseController
    {
        public ActionResult Index()
        {
            var model = HrMFMinistry.Drawer.Prepare();


            if (model == null)
                return HrMFMinistryState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DrawerModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HrMFMinistry.Drawer.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(DrawerModel model, FormCollection form)
        {
            var editDrawerId = IntValue(form["editDrawerId"]);
            var deleteDrawerId = IntValue(form["deleteDrawerId"]);

            // Select
            if (editDrawerId > 0)
                return Select(model, editDrawerId);

            // Delete
            if (deleteDrawerId > 0)
                return Delete(model, deleteDrawerId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.DrawerId == 0)
            {
                if (!HrMFMinistry.Drawer.Create(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            if (model.DrawerId > 0)
            {
                if (!HrMFMinistry.Drawer.Edit(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(DrawerModel model, int editDrawerId)
        {
            ModelState.Clear();
            model.DrawerId = editDrawerId;

            if (!HrMFMinistry.Drawer.Select(model))
                return AjaxHrMFMinistrytate("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(DrawerModel model, int deleteDrawerId)
        {
            ModelState.Clear();
            model.DrawerId = deleteDrawerId;  

            if (!HrMFMinistry.Drawer.Delete(model))
                return AjaxHrMFMinistrytate("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(DrawerModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<DrawerModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.DrawerGrid = loadedModel.DrawerGrid;
        }
    }
}