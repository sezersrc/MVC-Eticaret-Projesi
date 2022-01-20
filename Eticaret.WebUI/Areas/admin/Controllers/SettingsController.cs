using Eticaret.Business;
using Eticaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.WebUI.Areas.admin.Controllers
{
    public class SettingsController : Controller
    {
        // GET: admin/Settings

        //[Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            using (EntityContext db = new EntityContext())
            {
                return View(db.TBLSettings.ToList());
            }
        }
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert([Bind(Include = "ID,Name,Phone,CellPhone,VergiDairesi,VergiNO,Email,City,District,CompanyAdress,Password", Exclude = "Logo")] TBLSettings setting , HttpPostedFileBase upload)

        {
            try
            {

                using (EntityContext db = new EntityContext())
                {
                    if (upload != null)
                    {
                        setting.Logo = ImagesUpload.LogoUpload(upload);

                    }

                    db.TBLSettings.Add(setting);
                    db.SaveChanges();
                    ViewBag.Mesaj = "<div class=' alert-success' style='text-align:center; font-weight:bold; '>Kayıt Başarıyla Eklendi</div>";
                }
            }
            catch (Exception)
            {

                ViewBag.Mesaj = "<div class='alert alert-success' style='text-align:center;font-weight:bold'>Kayıt Eklenemedi Tekrar Deneyiniz</div>";
            }
            return View();
        }
        public ActionResult Update(int id)
        {
            using (EntityContext db = new EntityContext())
            {
                return View(db.TBLSettings.Where(x => x.ID == id).ToList());
            }

        }

        [HttpPost]
        public ActionResult Update([Bind(Include = "Name,Phone,CellPhone,VergiDairesi,VergiNO,Email,City,District,CompanyAdress,Password")]TBLSettings setting, HttpPostedFileBase upload, int id)

        {
            try
            {

                using (EntityContext db = new EntityContext())
                {
                    if (upload != null)
                    {
                        setting.Logo = ImagesUpload.LogoUpload(upload);
                    }

                    TBLSettings c = db.TBLSettings.Find(id);
                    c.ID = setting.ID;
                    c.Name = setting.Name;
                    c.Phone = setting.Phone;
                    c.CellPhone = setting.CellPhone;
                    c.VergiDairesi = setting.VergiDairesi;
                    c.VergiNO = setting.VergiNO;
                    c.Email = setting.Email;
                    c.City = setting.City;
                    c.District = setting.District;
                    c.CompanyAdress = setting.CompanyAdress;
                    c.Password = setting.Password;                    
                    db.SaveChanges();
                    ViewBag.Mesaj = "<div class='alert alert-success' style='text-align:center;font-weight:bold;width:100%'>Kayıt Başarıyla Güncellendi</div>";
                }
            }
            catch (Exception)
            {

                ViewBag.Mesaj = "<div class='alert alert-success' style='text-align:center;font-weight:bold;width:100%'>Kayıt Güncellenemedi Tekrar Deneyiniz</div>";
            }
            using (EntityContext db = new EntityContext())
            {
                return View(db.TBLSettings.Where(x => x.ID == id).ToList());
            }
        }

        public ActionResult Delete(int id)
        {

            using (EntityContext db = new EntityContext())
            {
                db.TBLSettings.Remove(db.TBLSettings.Find(id));
                db.SaveChanges();

            }
            return Redirect("/admin/Settings");
        }

    }
}