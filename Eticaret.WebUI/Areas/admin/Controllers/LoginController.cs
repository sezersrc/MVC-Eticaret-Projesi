using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticaret.Business;
using Eticaret.Entities;

namespace Eticaret.WebUI.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: admin/Login
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection Frm)
        {
            string KAdi = Request.Form["KullaniciAdi"];
            string KSifre = Request.Form["KullaniciSifre"];

            using (EntityContext db = new EntityContext())
            {
               

                if (db.TBLCustomer.Any(x => x.Email == KAdi && x.Password == KSifre))
                {
                    var data = db.TBLCustomer.Where(x => x.Email == KAdi && x.Password == KSifre).FirstOrDefault();

                    Cookies.CustomerInsert("Customer", data.CustomerID.ToString());
                    return Redirect("/");
                }
                else
                {
                    return View();
                }

            }

        }
    }
}