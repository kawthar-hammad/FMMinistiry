using Almotkaml.MFMinistry.Models;
using System.Web.Mvc;

namespace Almotkaml.MFMinistry.Mvc.Controllers
{
    public class BankController : BaseController
    {
        public ActionResult Index()
        {
            var model = HrMFMinistry.Bank.Prepare();

            if (model == null)
                return HrMFMinistryState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BankModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HrMFMinistry.Bank.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(BankModel model, FormCollection form)
        {
            var editBankId = IntValue(form["editBankId"]);
            var deleteBankId = IntValue(form["deleteBankId"]);

            // Select
            if (editBankId > 0)
                return Select(model, editBankId);

            // Delete
            if (deleteBankId > 0)
                return Delete(model, deleteBankId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.BankId == 0)
            {
                if (!HrMFMinistry.Bank.Create(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            if (model.BankId > 0)
            {
                if (!HrMFMinistry.Bank.Edit(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(BankModel model, int editBankId)
        {
            ModelState.Clear();
            model.BankId = editBankId;

            if (!HrMFMinistry.Bank.Select(model))
                return AjaxHrMFMinistrytate("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(BankModel model, int deleteBankId)
        {
            ModelState.Clear();
            model.BankId = deleteBankId;

            if (!HrMFMinistry.Bank.Delete(model))
                return AjaxHrMFMinistrytate("_Form", model);
            CallRedirect();

            return PartialView("_Form", model);
        }

        private void LoadModel(BankModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<BankModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.BankGrid = loadedModel.BankGrid;
        }
    }
}