using Eticaret.Business;
using Eticaret.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Eticaret.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly CrudeRepositorycs<TBLTempBasket> urun = new CrudeRepositorycs<TBLTempBasket>();

        // GET: Basket
        public ActionResult Index()
        {
            using (EntityContext db =new EntityContext())
            {
                ViewBag.Data = db.TBLSettings.ToList(); // Logo bölümünü çağırıyorum


                if (HttpContext.Request.Cookies["BasketCookiesID"] == null)
                {
                    return View();
                }
                else
                {
                    int SepetID = Convert.ToInt16(HttpContext.Request.Cookies["BasketCookiesID"]["BasketCookiesID"].ToString());
                    return View(urun.List(x => x.CookiesID == SepetID));

                }
            }
        }
    }
}