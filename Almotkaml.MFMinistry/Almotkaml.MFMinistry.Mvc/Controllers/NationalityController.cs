using Almotkaml.MFMinistry.Models;
using System.Web.Mvc;

namespace Almotkaml.MFMinistry.Mvc.Controllers
{
    public class NationalityController : BaseController
    {
        // GET: Nationality
        public ActionResult Index()
        {
            var model = HrMFMinistry.Nationality.Prepare();

            if (model == null)
                return HrMFMinistryState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(NationalityModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HrMFMinistry.Nationality.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(NationalityModel model, FormCollection form)
        {
            var editNationalityId = IntValue(form["editNationalityId"]);
            var deleteNationalityId = IntValue(form["deleteNationalityId"]);

            // Select
            if (editNationalityId > 0)
                return Select(model, editNationalityId);

            // Delete
            if (deleteNationalityId > 0)
                return Delete(model, deleteNationalityId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.NationalityId == 0)
            {
                if (!HrMFMinistry.Nationality.Create(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            if (model.NationalityId > 0)
            {
                if (!HrMFMinistry.Nationality.Edit(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(NationalityModel model, int editNationalityId)
        {
            ModelState.Clear();
            model.NationalityId = editNationalityId;

            if (!HrMFMinistry.Nationality.Select(model))
                return AjaxHrMFMinistrytate("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(NationalityModel model, int deleteNationalityId)
        {
            ModelState.Clear();
            model.NationalityId = deleteNationalityId;

            if (!HrMFMinistry.Nationality.Delete(model))
                return AjaxHrMFMinistrytate("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(NationalityModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<NationalityModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.NationalityGrid = loadedModel.NationalityGrid;
        }
    }
}