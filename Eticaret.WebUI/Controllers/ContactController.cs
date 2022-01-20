using Eticaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.WebUI.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            using (EntityContext db = new EntityContext())
            {

                ViewBag.Data = db.TBLSettings.ToList();
                return View();

            }

        }
    }
}