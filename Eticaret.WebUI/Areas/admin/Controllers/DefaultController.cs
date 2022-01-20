using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticaret.Entities;

namespace Eticaret.WebUI.Areas.admin.Controllers
{
    public class DefaultController : Controller
    {
        // GET: admin/Default

        //[Authorize(Roles = "admin")]


        public ActionResult Index()
        {

            using (EntityContext db =new EntityContext())
            {
                ViewBag.Data = db.TBLOrderCustomer.ToList(); // Müşteri adını Foreach döngüsüne gönderip ID ile eşleştirip basıyoruz Ekrana
                return View(db.TBLOrder.Where(x=>x.OrderStatus == "Yeni Sipariş" || x.OrderStatus == "Ödeme Bekleniyor" ).ToList());
            }
        }
    }
}