using Eticaret.Business;
using Eticaret.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Eticaret.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly CrudeRepositorycs<TBLTempBasket> urun = new CrudeRepositorycs<TBLTempBasket>();

        // GET: Payment
        public ActionResult Index()
        {
            using (EntityContext db = new EntityContext())
            {
                ViewBag.Data = db.TBLSettings.ToList();

                if (HttpContext.Request.Cookies["BasketCookiesID"] == null && Session["Uyeliksiz"] != null)
                {

                    return Redirect("/Customer");
                }

                else
                {
                    int SepetID = Convert.ToInt16(HttpContext.Request.Cookies["BasketCookiesID"]["BasketCookiesID"]);

                    return View(urun.List(x => x.CookiesID == SepetID));
                }

            }

        }


        [HttpPost]

        public ActionResult Index(FormCollection Frm)
        {
            try
            {
                int MusteriID = 0;

                if (HttpContext.Request.Cookies["Customer"] != null)
                {
                    MusteriID = Convert.ToInt16(HttpContext.Request.Cookies["Customer"]["Customer"].ToString());
                }

                int SepetID = Convert.ToInt16(HttpContext.Request.Cookies["BasketCookiesID"]["BasketCookiesID"]);

                bool sonuc = false;

                decimal Toplam = 0;
                if (Request.Form["OdemeYontemi"] == "Kapıda Ödeme")
                {
                    using (EntityContext db = new EntityContext())

                    {

                        ViewBag.Data = db.TBLSettings.ToList();

                        TBLOrder order = new TBLOrder();
                        order.CargoPrice = 0;
                        order.KDV = 18;
                        order.MusteriID = MusteriID;
                        order.OrderID = SepetID;
                        order.PaymentTime = DateTime.Now;
                        order.PaymentType = "Kapıda Ödeme ";
                        order.OrderStatus = "Yeni Sipariş";

                        foreach (var item in db.TBLTempBasket.Where(x => x.CookiesID == SepetID).ToList())
                        {
                            Toplam += item.Piece * item.Price;
                            TBLOrderDetail od = new TBLOrderDetail(); // Order Detail'e ürünleri taşıyoruz . 
                            od.DiscountPrice = item.DiscountPrice;
                            od.Price = item.Price;
                            od.Piece = item.Piece;
                            od.images = item.images;
                            od.Name = item.Name;
                            od.ProductID = item.ProductID;
                            od.OrderID = SepetID;
                            db.TBLOrderDetail.Add(od);
                            db.SaveChanges();

                            db.TBLTempBasket.Remove(db.TBLTempBasket.Find(item.BasketID)); // Taşıdıkdan sonra geçici sepetten siliyoruz.
                            db.SaveChanges();


                        }

                        order.TotalPrice = Toplam;
                        db.TBLOrder.Add(order);
                        db.SaveChanges();

                    }

                    sonuc = true;
                }
                else if (Request.Form["OdemeYontemi"] == "Havale İle Ödeme")
                {
                    using (EntityContext db = new EntityContext())
                    {

                        ViewBag.Data = db.TBLSettings.ToList();

                        TBLOrder order = new TBLOrder();
                        order.CargoPrice = 0;
                        order.KDV = 18;
                        order.MusteriID = MusteriID;
                        order.OrderID = SepetID;
                        order.PaymentTime = DateTime.Now;
                        order.PaymentType = "Havale ";
                        order.OrderStatus = "Yeni Sipariş";

                        foreach (var item in db.TBLTempBasket.Where(x => x.CookiesID == SepetID).ToList())
                        {
                            Toplam += item.Piece * item.Price;
                            TBLOrderDetail od = new TBLOrderDetail(); // Order Detail'e ürünleri taşıyoruz . 
                            od.DiscountPrice = item.DiscountPrice;
                            od.Price = item.Price;
                            od.Piece = item.Piece;
                            od.images = item.images;
                            od.Name = item.Name;
                            od.ProductID = item.ProductID;
                            od.OrderID = SepetID;
                            db.TBLOrderDetail.Add(od);
                            db.SaveChanges();

                            db.TBLTempBasket.Remove(db.TBLTempBasket.Find(item.BasketID)); // Taşıdıkdan sonra geçici sepetten siliyoruz.
                            db.SaveChanges();


                        }

                        order.TotalPrice = Toplam;
                        db.TBLOrder.Add(order);
                        db.SaveChanges();

                    }

                    sonuc = true;

                }
                else // Kredi Kartı ÖDeme
                {
                    using (EntityContext db = new EntityContext())
                    {

                        ViewBag.Data = db.TBLSettings.ToList();

                        TBLOrder order = new TBLOrder();
                        order.CargoPrice = 0;
                        order.KDV = 18;
                        order.MusteriID = MusteriID;
                        order.OrderID = SepetID;
                        order.PaymentTime = DateTime.Now;
                        order.PaymentType = " Kredi Kartı ";
                        order.OrderStatus = " Yeni Sipariş";

                        foreach (var item in db.TBLTempBasket.Where(x => x.CookiesID == SepetID).ToList())
                        {
                            Toplam += item.Piece * item.Price;
                            TBLOrderDetail od = new TBLOrderDetail(); // Order Detail'e ürünleri taşıyoruz . 
                            od.DiscountPrice = item.DiscountPrice;
                            od.Price = item.Price;
                            od.Piece = item.Piece;
                            od.images = item.images;
                            od.Name = item.Name;
                            od.ProductID = item.ProductID;
                            od.OrderID = SepetID;
                            db.TBLOrderDetail.Add(od);
                            db.SaveChanges();

                            db.TBLTempBasket.Remove(db.TBLTempBasket.Find(item.BasketID)); // Taşıdıkdan sonra geçici sepetten siliyoruz.
                            db.SaveChanges();


                        }

                        order.TotalPrice = Toplam;
                        db.TBLOrder.Add(order);
                        db.SaveChanges();

                    }

                    sonuc = true;
                }

                // Satın alan Müşteri Bilgileri 

                using (EntityContext dbc = new EntityContext())
                {

                    ViewBag.Data = dbc.TBLSettings.ToList();

                    TBLOrderCustomer oc = new TBLOrderCustomer();
                    oc.NameSurName = Request.Form["NameSurName"];
                    oc.Phone = Request.Form["Phone"];
                    oc.City = Request.Form["City"];
                    oc.District = Request.Form["District"];
                    oc.FullAddress = Request.Form["FullAddress"];
                    oc.OrderID = SepetID;
                    dbc.TBLOrderCustomer.Add(oc);
                    dbc.SaveChanges();
                }





                // Eğer Yukarı Ödeme Metotları Sorunsuz Çalıştıysa Artık Veritabanına Sipariş Adres bilgileri ve diğer Sipariş Bilgilerini Kaydediyoruz.
                if (sonuc)
                {
                    // İşlem Başarılıysa Burası
                    TempData["İşlem Sonucu"] = "Satın Alma İşleminiz Başarılı bir şekilde tamamlandı . Sipariş Numaranız : <b>" + SepetID + "</b >";

                    return Redirect("/Payment/Basarili");
                }
                else
                {
                    // İşlem Başarısız ise Burası Çalışacaktır.

                    TempData["İşlem Sonucu"] = "Satın Alma İşleminiz  tamamlanamadı </b >";

                    return Redirect("/Payment/Basarisiz");
                }
            }
            catch (Exception e)
            {
                LogKayit.LogInsert(e, "PaymentController.cs - Payment POST Hata.");
            }


            return View();
        }

        public ActionResult Basarili()
        {
            Response.Cookies["BasketCookiesID"].Expires = DateTime.Now.AddDays(-5);
            return View();
        }

        public ActionResult Basarisiz()
        {
            return View();
        }

    }
}