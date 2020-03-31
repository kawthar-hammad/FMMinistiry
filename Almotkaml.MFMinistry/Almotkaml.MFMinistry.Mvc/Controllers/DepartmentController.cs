using Almotkaml.MFMinistry.Models;
using System.Web.Mvc;

namespace Almotkaml.MFMinistry.Mvc.Controllers
{
    public class DepartmentController : BaseController
    {
        // GET: CostCenter
        public ActionResult Index()
        {
            var model = HrMFMinistry.Department.Prepare();

            if (model == null)
                return HrMFMinistryState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DepartmentModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HrMFMinistry.Department.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(DepartmentModel model, FormCollection form)
        {
            var editDepartmentId = IntValue(form["editDepartmentId"]);
            var deleteDepartmentId = IntValue(form["deleteDepartmentId"]);

            // Select
            if (editDepartmentId > 0)
                return Select(model, editDepartmentId);

            // Delete
            if (deleteDepartmentId > 0)
                return Delete(model, deleteDepartmentId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.DepartmentId == 0)
            {
                if (!HrMFMinistry.Department.Create(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            if (model.DepartmentId > 0)
            {
                if (!HrMFMinistry.Department.Edit(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(DepartmentModel model, int DepartmentId)
        {
            ModelState.Clear();
            model.DepartmentId = DepartmentId;

            if (!HrMFMinistry.Department.Select(model))
                return AjaxHrMFMinistrytate("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(DepartmentModel model, int DepartmentId)
        {
            ModelState.Clear();
            model.DepartmentId = DepartmentId;

            if (!HrMFMinistry.Department.Delete(model))
                return AjaxHrMFMinistrytate("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(DepartmentModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<DepartmentModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.DepartmentGrid = loadedModel.DepartmentGrid;
        }
    }
}