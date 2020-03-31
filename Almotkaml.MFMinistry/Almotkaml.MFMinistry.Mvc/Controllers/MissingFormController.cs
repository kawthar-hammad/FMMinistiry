using Almotkaml.MFMinistry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almotkaml.MFMinistry.Mvc.Controllers
{
    public class MissingFormController : BaseController
    {
        // GET: Missing
        public ActionResult Index()
        {
            var model = HrMFMinistry.MissingForm.Index();

            if (model == null)
                return HrMFMinistryState();

            return View(model);
        }

        // GET: Missing/Create
        public ActionResult Create()
        {
            var model = HrMFMinistry.MissingForm.Prepare();

            if (model == null)
                return HrMFMinistryState();

            return View(model);
        }

        // POST: Missing/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MissingFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            HrMFMinistry.MissingForm.Refresh(model);

            if (save == null)
                return View(model);

            if (!ModelState.IsValid)
                return View(model);

            if (!HrMFMinistry.MissingForm.Create(model))
                return HrMFMinistryState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }

        // GET: Missing/Edit/5
        public ActionResult Edit(int id)
        {
            var model = HrMFMinistry.MissingForm.Find(id);

            if (model == null)
                return HrMFMinistryState();

            SaveModel(model);

            return View(model);
        }

        // POST: Missing/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MissingFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            HrMFMinistry.MissingForm.Refresh(model);

            if (save == null)
                return View(model);

            if (!ModelState.IsValid)
                return View(model);

            if (!HrMFMinistry.MissingForm.Edit(id, model))
                return HrMFMinistryState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }


        // GET: Missing/Delete/5
        public ActionResult Delete(int id)
        {
            var model = HrMFMinistry.MissingForm.Find(id);

            if (model == null)
                return HrMFMinistryState();

            return View(model);
        }

        // POST: Missing/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool? post)
        {
            ModelState.Clear();
            var model = HrMFMinistry.MissingForm.Find(id);
            if (!HrMFMinistry.MissingForm.Delete(id, model))
                return HrMFMinistryState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }

        private void LoadModel(MissingFormModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<MissingFormModel>(savedModel);
            if (loadedModel == null)
                return;

           // model.CanSubmit = loadedModel.CanSubmit;
        }
    }
}