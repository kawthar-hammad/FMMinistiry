using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almotkaml.MFMinistry.Mvc.Controllers
{
    public class MainController : BaseController
    {
        int Ischeck;
        public ActionResult IndexIscheck(int? id)
        {
            Ischeck = id??0;
            return Index();
        }
        // GET: Main
        public ActionResult Index()
        {
           
            var model = HrMFMinistry.Account.Prepare();
            model.CheckUserPerm = Ischeck;
            if (model == null)
                return HrMFMinistryState();

            return View(model);
        }

    }
}