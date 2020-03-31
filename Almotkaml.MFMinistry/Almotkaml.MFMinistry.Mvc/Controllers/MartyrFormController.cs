using Almotkaml.MFMinistry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almotkaml.MFMinistry.Mvc.Controllers
{
    public class MartyrFormController : BaseController
    {
        // GET: Martyr
        public ActionResult Index()
        {
            var model = HrMFMinistry.MartyrForm.Index();

            if (model == null)
                return HrMFMinistryState();

            return View(model);
        }

        // GET: Martyr/Create
        public ActionResult Create()
        {
            var model = HrMFMinistry.MartyrForm.Prepare();

            if (model == null)
                return HrMFMinistryState();

            return View(model);
        }

        // POST: Martyr/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MartyrFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            HrMFMinistry.MartyrForm.Refresh(model);

            if (save == null)
                return View(model);

            if (!ModelState.IsValid)
                return View(model);

            if (!HrMFMinistry.MartyrForm.Create(model))
                return HrMFMinistryState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }

        // GET: Martyr/Edit/5
        public ActionResult Edit(int id)
        {
            var model = HrMFMinistry.MartyrForm.Find(id);

            if (model == null)
                return HrMFMinistryState();

            SaveModel(model);

            return View(model);
        }

        // POST: Martyr/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MartyrFormModel model, string save, string savedModel)
        {
            LoadModel(model, savedModel);

            HrMFMinistry.MartyrForm.Refresh(model);

            if (save == null)
                return View(model);

            if (!ModelState.IsValid)
                return View(model);

            if (!HrMFMinistry.MartyrForm.Edit(id, model))
                return HrMFMinistryState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }


        // GET: Martyr/Delete/5
        public ActionResult Delete(int id)
        {
            var model = HrMFMinistry.MartyrForm.Find(id);

            if (model == null)
                return HrMFMinistryState();

            return View(model);
        }

        // POST: Martyr/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool? post)
        {
            ModelState.Clear();
            var model = HrMFMinistry.MartyrForm.Find(id);
            if (!HrMFMinistry.MartyrForm.Delete(id, model))
                return HrMFMinistryState(model);

            SuccessNote();

            return RedirectToAction(nameof(Index));
        }

        private void LoadModel(MartyrFormModel model, string savedModel)
        {
            var loadedModel = LoadSavedModel<MartyrFormModel>(savedModel);
            if (loadedModel == null)
                return;

           // model.CanSubmit = loadedModel.CanSubmit;
        }
    }
}