using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticaret.Entities;

namespace Eticaret.WebUI.Areas.admin.Controllers
{
    public class CustomersController : Controller
    {
        // GET: admin/Customers
       // [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            using (EntityContext db = new EntityContext())
            {
                return View(db.TBLCustomer.ToList());
            }
        }
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert([Bind(Include = "NSurname,Email,Phone,Password")] TBLCustomer customer)

        {
            try
            {

                using (EntityContext db = new EntityContext())
                {

                    db.TBLCustomer.Add(customer);
                    db.SaveChanges();                    
                    ViewBag.Data = "<div class=' alert-success' style='text-align:center; font-weight:bold; '>Kayıt Başarıyla Eklendi</div>";
                }
            }
            catch (Exception)
            {

                ViewBag.Data = "<div class='alert alert-success' style='text-align:center;font-weight:bold'>Kayıt Eklenemedi Tekrar Deneyiniz</div>";
            }
            return View();
        }
        public ActionResult Update(int ID)
        {
            using (EntityContext db = new EntityContext())
            {
                return View(db.TBLCustomer.Where(x=>x.CustomerID == ID).ToList());
            }

        }

        [HttpPost]
        public ActionResult Update([Bind(Include = "NSurname,Email,Phone,Password")] TBLCustomer customer, int ID)

        {
            try
            {

                using (EntityContext db = new EntityContext())
                {
                    TBLCustomer c = db.TBLCustomer.Find(ID);
                    c.NSurname = customer.NSurname;
                    c.Email = customer.Email;
                    c.Phone = customer.Phone;
                    c.Password = customer.Password;                
                    db.SaveChanges();
                    ViewBag.Data = "<div class='alert alert-success' style='text-align:center;font-weight:bold;width:100%'>Kayıt Başarıyla Güncellendi</div>";
                }
            }
            catch (Exception)
            {

                ViewBag.Data = "<div class='alert alert-success' style='text-align:center;font-weight:bold;width:100%'>Kayıt Güncellenemedi Tekrar Deneyiniz</div>";
            }
            using (EntityContext db = new EntityContext())
            {
                return View(db.TBLCustomer.Where(x => x.CustomerID == ID).ToList());
            }
        }

        public ActionResult Delete(int ID)
        {

            using (EntityContext db = new EntityContext())
            {
                db.TBLCustomer.Remove(db.TBLCustomer.Find(ID));
                db.SaveChanges();

            }
            return Redirect("/admin/Customers");
        }
}    }