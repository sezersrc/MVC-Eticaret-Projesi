using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticaret.Entities;
using Eticaret.Business;


namespace Eticaret.WebUI.Areas.admin.Controllers
{
    public class CategorysController : Controller
    {
        // GET: admin/Categorys
        //[Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            using (EntityContext db = new EntityContext())
            {
                return View(db.TBLCategory.ToList());
            }
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert([Bind(Include = "Name,MenuOrder,Status", Exclude = "CategorySeo")] TBLCategory category)

        {
            try
            {

                using (EntityContext db = new EntityContext())
                {
                    category.CategorySeo = ClearCharacter.Clear(category.Name);
                    category.Status = true;
                    db.TBLCategory.Add(category);
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
                return View(db.TBLCategory.Where(x => x.CategoryID == ID).ToList());
            }
            
        }

        [HttpPost]
        public ActionResult Update([Bind(Include = "Name,MenuOrder,Status", Exclude = "CategorySeo,")] TBLCategory category, int ID)

        {
            try
            {

                using (EntityContext db = new EntityContext())
                {
                    TBLCategory c = db.TBLCategory.Find(ID);
                    c.Name = category.Name;
                    c.MenuOrder = category.MenuOrder;
                    c.Status = category.Status;                   
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
                return View(db.TBLCategory.Where(x => x.CategoryID == ID).ToList());
            }

        }
        


        public ActionResult Delete(int ID)
        {

            using (EntityContext db = new EntityContext())
            {
                db.TBLCategory.Remove(db.TBLCategory.Find(ID));
                db.SaveChanges();

            }
            return Redirect("/admin/Categorys");
        }


    }
}
   

