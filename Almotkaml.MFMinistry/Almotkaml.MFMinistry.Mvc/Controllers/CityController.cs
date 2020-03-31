using Almotkaml.MFMinistry.Models;
using System.Web.Mvc;

namespace Almotkaml.MFMinistry.Mvc.Controllers
{
    public class CityController : BaseController
    {
        // GET: City
        public ActionResult Index()
        {
            var model = HrMFMinistry.City.Prepare();

            if (model == null)
                return HrMFMinistryState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CityModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HrMFMinistry.City.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(CityModel model, FormCollection form)
        {
            var editCityId = IntValue(form["editCityId"]);
            var deleteCityId = IntValue(form["deleteCityId"]);

            // Select
            if (editCityId > 0)
                return Select(model, editCityId);

            // Delete
            if (deleteCityId > 0)
                return Delete(model, deleteCityId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.CityId == 0)
            {
                if (!HrMFMinistry.City.Create(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            if (model.CityId > 0)
            {
                if (!HrMFMinistry.City.Edit(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(CityModel model, int editCityId)
        {
            ModelState.Clear();
            model.CityId = editCityId;

            if (!HrMFMinistry.City.Select(model))
                return AjaxHrMFMinistrytate("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(CityModel model, int deleteCityId)
        {
            ModelState.Clear();
            model.CityId = deleteCityId;

            if (!HrMFMinistry.City.Delete(model))
                return AjaxHrMFMinistrytate("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(CityModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<CityModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.CityGrid = loadedModel.CityGrid;
            model.CountryList = loadedModel.CountryList;
        }
    }
}

