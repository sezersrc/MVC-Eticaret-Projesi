using Eticaret.Business;
using System;
using System.Linq;
using System.Web.Mvc;
using Eticaret.Entities;

namespace Eticaret.WebUI.Controllers
{
    public class PartialViewController : Controller
    {
        private readonly ConnectionBase db = new ConnectionBase();
       

        // GET: PartialView
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SepetAdetKontrol()
        {
            if (HttpContext.Request.Cookies["BasketCookiesID"] != null)
            {
                int SepetID = Convert.ToInt16(HttpContext.Request.Cookies["BasketCookiesID"]["BasketCookiesID"].ToString());
                return View("/Views/PartialPage/_PartialSepetAdetKontrol.cshtml", db.context.TBLTempBasket.Where(x => x.CookiesID == SepetID).Count());
            }
            else
            {
                return View("/Views/PartialPage/_PartialSepetAdetKontrol.cshtml", db.context.TBLTempBasket.Where(x => x.CookiesID == 0).Count());
            }

        }
        
       
    }

}