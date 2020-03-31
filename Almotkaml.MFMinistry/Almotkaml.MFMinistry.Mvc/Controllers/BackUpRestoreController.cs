using System;
using System.Configuration;
using System.IO;

namespace Almotkaml.MFMinistry.Mvc.Controllers
{
    public class BackUpRestoreController : BaseController
    {
        // GET: BackUpRestore
        public string Index()
        {
            var backUpFolder = ConfigurationManager.AppSettings["BackUpFolder"];
            Directory.CreateDirectory(backUpFolder);

            var path = backUpFolder + "B" + DateTime.Now.ToString("yyMMddHHmmss") + ".bak";

            return HrMFMinistry.BackUpRestore.BackUp(path) ? path : "Failed";
        }
    }
}