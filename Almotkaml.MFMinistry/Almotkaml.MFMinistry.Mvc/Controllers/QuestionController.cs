using Almotkaml.MFMinistry.Models;
using System.Web.Mvc;

namespace Almotkaml.MFMinistry.Mvc.Controllers
{
    public class QuestionController : BaseController
    {
        // GET: CostCenter
        public ActionResult Index()
        {
            var model = HrMFMinistry.Question.Prepare();

            if (model == null)
                return HrMFMinistryState();

            SaveModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(QuestionModel model, FormCollection form)
        {
            LoadModel(model, form["savedModel"]);

            HrMFMinistry.Question.Refresh(model);

            if (!Request.IsAjaxRequest())
                return AjaxNotWorking();

            return AjaxIndex(model, form);
        }

        private PartialViewResult AjaxIndex(QuestionModel model, FormCollection form)
        {
            var editQuestionId = IntValue(form["editQuestionId"]);
            var deleteQuestionId = IntValue(form["deleteQuestionId"]);

            // Select
            if (editQuestionId > 0)
                return Select(model, editQuestionId);

            // Delete
            if (deleteQuestionId > 0)
                return Delete(model, deleteQuestionId);

            // Insert
            if (!ModelState.IsValid)
                return PartialView("_Form", model);

            if (model.QuestionId == 0)
            {
                if (!HrMFMinistry.Question.Create(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            if (model.QuestionId > 0)
            {
                if (!HrMFMinistry.Question.Edit(model))
                    return AjaxHrMFMinistrytate("_Form", model);
            }

            CallRedirect();
            return PartialView("_Form", model);
        }
        private PartialViewResult Select(QuestionModel model, int editQuestionId)
        {
            ModelState.Clear();
            model.QuestionId = editQuestionId;

            if (!HrMFMinistry.Question.Select(model))
                return AjaxHrMFMinistrytate("_Form", model);

            return PartialView("_Form", model);
        }
        private PartialViewResult Delete(QuestionModel model, int deleteQuestionId)
        {
            ModelState.Clear();
            model.QuestionId = deleteQuestionId;

            if (!HrMFMinistry.Question.Delete(model))
                return AjaxHrMFMinistrytate("_Form", model);
            CallRedirect();
            return PartialView("_Form", model);
        }

        private void LoadModel(QuestionModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<QuestionModel>(savedModel);

            if (loadedModel == null)
                return;

            model.CanCreate = loadedModel.CanCreate;
            model.CanEdit = loadedModel.CanEdit;
            model.CanDelete = loadedModel.CanDelete;
            model.QuestionGrid = loadedModel.QuestionGrid;
        }

    }
}