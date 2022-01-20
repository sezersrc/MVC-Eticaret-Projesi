using Eticaret.Entities;
using Eticaret.Business;
using System.Linq;
using System.Web.Mvc;
using System;

namespace Eticaret.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            using (EntityContext db = new EntityContext())
            {

                ViewBag.Data = db.TBLSettings.ToList();
                return View();

            }
           
        }

        [HttpPost]
        public ActionResult Index(FormCollection Frm)
        {
            string KAdi = Request.Form["KullaniciAdi"];
            string KSifre = Request.Form["KullaniciSifre"];

            using (EntityContext db = new EntityContext())
            {
                ViewBag.Data = db.TBLSettings.ToList();

                if (db.TBLCustomer.Any(x=> x.Email == KAdi && x.Password == KSifre))
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

        [HttpPost]
        public ActionResult Uyeliksiz()
        {
            Session["Uyeliksiz"] = "1";
            return Redirect("/Payment");
        }
        [HttpPost]
        public ActionResult Register([Bind(Include = "NSurname,Email,Phone,Password")]TBLCustomer customer)
        {
            using (EntityContext db = new EntityContext())
            {
                ViewBag.Data = db.TBLSettings.ToList();
                if (db.TBLCustomer.Any(x=> x.Phone == customer.Phone && x.Email == customer.Email))
                {
                    TempData["Error"] = "Email Adresine Veya  Telefon Numarasına ait üye kaydı bulunmaktadır . ";
                    return Redirect("/Customer");
                }
                else
                {
                    db.TBLCustomer.Add(customer);
                    db.SaveChanges();

                    // ID'ye göre Kullanıcıyı Getir .
                    Cookies.CustomerInsert("Customer", db.TBLCustomer.Where(x => x.Email == customer.Email && x.Phone == customer.Phone).FirstOrDefault().CustomerID.ToString());

                    return Redirect("/");
                }
                
            }
        }
        public ActionResult Info()
        {
            using (EntityContext db = new EntityContext())
            {
                int CID = Convert.ToInt16(HttpContext.Request.Cookies["Customer"]["Customer"].ToString());

                ViewBag.Data = db.TBLSettings.ToList();
                return View(db.TBLCustomer.Where(x=> x.CustomerID == CID).ToList());
            }
           
        }

        public ActionResult Logout()
        {

            Response.Cookies["Customer"].Expires = DateTime.Now.AddDays(-5);
            return Redirect("/");

        }
        public ActionResult Orders()
        {
            using (EntityContext db = new EntityContext()) 
            {
                ViewBag.Data = db.TBLSettings.ToList();
                int CID = Convert.ToInt16(HttpContext.Request.Cookies["Customer"]["Customer"].ToString());

                ViewBag.OrderData = db.TBLOrderDetail.ToList();
                return View(db.TBLOrder.Where(x=> x.MusteriID == CID).ToList());
            }
         
        }

    }
      
    
}