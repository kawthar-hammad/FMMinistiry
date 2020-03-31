using Almotkaml.MFMinistry.Business;
using Almotkaml.MFMinistry.Models;
using Almotkaml.MFMinistry.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almotkaml.MFMinistry.Mvc.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var model = HrMFMinistry.Home.View();

            if (model == null)
                return HrMFMinistryState();

            return View(model);
        }
  
    }
}
