using Almotkaml.MFMinistry.Models;
using System.Web.Mvc;

namespace Almotkaml.MFMinistry.Mvc.Controllers
{
    public class CountryController : BaseController
    {
        // GET: CostCenter
        public ActionResult Index()
        {
            var model = HrMFMinistry.Country.Prepare();

            if (model == null)
                return HrMFMinistryState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CountryModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HrMFMinistry.Country.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(CountryModel model, FormCollection form)
        {
            var editCountryId = IntValue(form["editCountryId"]);
            var deleteCountryId = IntValue(form["deleteCountryId"]);

            // Select
            if (editCountryId > 0)
                return Select(model, editCountryId);

            // Delete
            if (deleteCountryId > 0)
                return Delete(model, deleteCountryId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.CountryId == 0)
            {
                if (!HrMFMinistry.Country.Create(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            if (model.CountryId > 0)
            {
                if (!HrMFMinistry.Country.Edit(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(CountryModel model, int editCountryId)
        {
            ModelState.Clear();
            model.CountryId = editCountryId;

            if (!HrMFMinistry.Country.Select(model))
                return AjaxHrMFMinistrytate("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(CountryModel model, int deleteCountryId)
        {
            ModelState.Clear();
            model.CountryId = deleteCountryId;

            if (!HrMFMinistry.Country.Delete(model))
                return AjaxHrMFMinistrytate("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(CountryModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<CountryModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.CountryGrid = loadedModel.CountryGrid;
        }
    }
}