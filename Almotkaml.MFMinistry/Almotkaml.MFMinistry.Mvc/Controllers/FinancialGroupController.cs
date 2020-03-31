using Almotkaml.MFMinistry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almotkaml.MFMinistry.Mvc.Controllers
{
    public class FinancialGroupController : BaseController
    {
        // GET: FinancialGroup
        public ActionResult Index()
        {
            var model = HrMFMinistry.FinancialGroup.Prepare();

            if (model == null)
                return HrMFMinistryState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FinancialGroupModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HrMFMinistry.FinancialGroup.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(FinancialGroupModel model, FormCollection form)
        {
            var editFinancialGroupId = IntValue(form["editFinancialGroupId"]);
            var deleteFinancialGroupId = IntValue(form["deleteFinancialGroupId"]);

            // Select
            if (editFinancialGroupId > 0)
                return Select(model, editFinancialGroupId);

            // Delete
            if (deleteFinancialGroupId > 0)
                return Delete(model, deleteFinancialGroupId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.FinancialGroupId == 0)
            {
                if (!HrMFMinistry.FinancialGroup.Create(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            if (model.FinancialGroupId > 0)
            {
                if (!HrMFMinistry.FinancialGroup.Edit(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(FinancialGroupModel model, int editFinancialGroupId)
        {
            ModelState.Clear();
            model.FinancialGroupId = editFinancialGroupId;

            if (!HrMFMinistry.FinancialGroup.Select(model))
                return AjaxHrMFMinistrytate("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(FinancialGroupModel model, int deleteFinancialGroupId)
        {
            ModelState.Clear();
            model.FinancialGroupId = deleteFinancialGroupId;

            if (!HrMFMinistry.FinancialGroup.Delete(model))
                return AjaxHrMFMinistrytate("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(FinancialGroupModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<FinancialGroupModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.FinancialGroupGrid = loadedModel.FinancialGroupGrid;
        }
    }
}