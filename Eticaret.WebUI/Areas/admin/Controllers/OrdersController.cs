using Eticaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.WebUI.Areas.admin.Controllers
{
    public class OrdersController : Controller
    {
        // GET: admin/Orders
       // [Authorize(Roles = "admin")]

        public ActionResult Index()
        {

            using (EntityContext db = new EntityContext())
            {
                ViewBag.Data = db.TBLOrderCustomer.ToList(); // Müşteri adını Foreach döngüsüne gönderip ID ile eşleştirip basıyoruz Ekrana
                //return View(db.TBLOrder.ToList());

                return View(db.TBLOrder.ToList());
                //PaymentTime.ToString("dd.mm.yyy - HH:ss")
                //
            }
        }
        public ActionResult Details()
        {

            using (EntityContext db = new EntityContext())
            {
                ViewBag.Data = db.TBLOrderCustomer.ToList(); // Müşteri adını Foreach döngüsüne gönderip ID ile eşleştirip basıyoruz Ekrana
                //return View(db.TBLOrder.ToList());

                return View(db.TBLOrder.ToList());
                //PaymentTime.ToString("dd.mm.yyy - HH:ss")
                
            }
        }
        public ActionResult Update(int ID)
        {
            using (EntityContext db = new EntityContext())
            {
                ViewBag.Data = db.TBLOrderCustomer.Where(x => x.OrderID == ID).ToList();
                return View(db.TBLOrder.Where(x => x.OrderID == ID).ToList());
            }
        }

        [HttpPost]
        public ActionResult Update([Bind(Include = "OrderID,CargoPrice,MusteriID,TotalPrice,KDV,PaymentType,PaymentTime,CargoNumber,OrderStatus")] TBLOrder order , int ID ) // Upload = Yüklenecek resim Ürün REsmi

        {
            try
            {

                using (EntityContext db = new EntityContext())
                {
                                        
                    TBLOrder o = db.TBLOrder.Find(ID);
                    o.OrderID = order.OrderID;
                    o.CargoPrice = order.CargoPrice;
                    o.MusteriID = order.MusteriID;
                    o.TotalPrice = order.TotalPrice;
                    o.KDV = order.KDV;
                    o.PaymentTime = order.PaymentTime;
                    o.PaymentType = order.PaymentType;
                    o.CargoNumber = order.CargoNumber;
                    o.OrderStatus = order.OrderStatus;                    
                    db.SaveChanges();

                    ViewBag.Mesaj = "<div class=' alert-success' style='text-align:center; font-weight:bold; '>Kayıt Başarıyla Güncellendi</div>";
                }
            }
            catch (Exception)
            {

                ViewBag.Mesaj = "<div class='alert alert-success' style='text-align:center;font-weight:bold'>Kayıt Eklenemedi Tekrar Deneyiniz</div>";
            }

            using (EntityContext db = new EntityContext())
            {
                // ViewBag.Data = db.TBLOrderCustomer.Where(x => x.OrderID == ID).ToList();

                return View(db.TBLOrder.Where(x => x.OrderID == ID).ToList());

               // return View(db.TBLOrder.ToList());
            }
        }
        public ActionResult Delete(int ID)
        {

            using (EntityContext db = new EntityContext())
            {
                db.TBLOrder.Remove(db.TBLOrder.Find(ID));
                db.SaveChanges();

            }
            return Redirect("/admin/Orders");
        }
    }
}