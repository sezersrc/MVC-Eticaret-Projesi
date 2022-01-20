using System;
using Eticaret.Business;
using Eticaret.Entities;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace Eticaret.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly CrudeRepositorycs<TBLProduct> urun = new CrudeRepositorycs<TBLProduct>();

        // GET: Home
        //[Authorize(Roles = "user")]
        public ActionResult Index(string ara, int sayfa=1)
        {
            using (EntityContext db = new EntityContext())
            {

                ViewBag.Data = db.TBLSettings.ToList();
                ViewBag.Category = db.TBLCategory.ToList();
                return View(db.TBLProduct.Where(x => x.Name.Contains(ara) || ara == null).ToList().ToPagedList(sayfa, 10));
            }


        }
    }
}