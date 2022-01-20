using Eticaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.WebUI.Controllers
{
    public class CompanyInfoController : Controller
    {
        // GET: CompanyInfo
        public ActionResult PartiaLInfo()
        {
            using (EntityContext db = new EntityContext())
            {
                return PartialView("/Views/PartialPage/_PartialHeaderInfo.cshtml", db.TBLSettings.ToList());
            }


        }
    }
}