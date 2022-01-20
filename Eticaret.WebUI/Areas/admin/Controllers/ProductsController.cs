using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eticaret.Entities;
using Eticaret.Business;

namespace Eticaret.WebUI.Areas.admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: admin/Products
        //[Authorize(Roles = "admin")]

        public ActionResult Index()
        {
            using (EntityContext db = new EntityContext())
            {                
                return View(db.TBLProduct.ToList());
            }
        }

        public ActionResult Insert()
        {
            using (EntityContext db = new EntityContext())
            {
                ViewBag.Image = db.TBLImages.ToList();
                return View(db.TBLCategory.ToList());
            }
        }

        [HttpPost]
        public ActionResult Insert([Bind(Include = "CategoryID,Name,Price,DiscountPrice,Stock,Status,Details", Exclude = "images")] TBLProduct product , HttpPostedFileBase upload) // Upload = Yüklenecek resim Ürün REsmi

        {
            try
            {
               
                using (EntityContext db = new EntityContext())
                {

                    if (upload != null)
                    {
                        product.images = ImagesUpload.Upload(upload);
                    }                   
                    

                    db.TBLProduct.Add(product);
                    db.SaveChanges();                    
                    ViewBag.Data = "<div class=' alert-success' style='text-align:center; font-weight:bold; '>Kayıt Başarıyla Eklendi</div>";
                }
            }
            catch (Exception)
            {

                ViewBag.Data = "<div class='alert alert-success' style='text-align:center;font-weight:bold'>Kayıt Eklenemedi Tekrar Deneyiniz</div>";
            }
            using (EntityContext db = new EntityContext())
            {
                return View(db.TBLCategory.ToList());
            }
        }

        public ActionResult Update(int ID)
        {
            using (EntityContext db = new EntityContext())
            {
                ViewBag.Data = db.TBLProduct.Where(x => x.ProductID == ID).ToList();
                return View(db.TBLCategory.ToList());
            }
        }

        [HttpPost]
        public ActionResult Update([Bind(Include = "CategoryID,Name,Price,DiscountPrice,Stock,Status,Details", Exclude = "images")] TBLProduct product, HttpPostedFileBase upload , int ID) // Upload = Yüklenecek resim Ürün REsmi

        {
            try
            {

                using (EntityContext db = new EntityContext())
                {

                    if (upload != null)
                    {
                        product.images = ImagesUpload.Upload(upload);
                    }
                    TBLProduct p = db.TBLProduct.Find(ID);
                    p.Status = product.Status;
                    p.Stock = product.Stock;
                    p.Name = product.Name;
                    p.Price = product.Price;
                    p.DiscountPrice = product.DiscountPrice;
                    p.CategoryID = product.CategoryID;
                    p.Details = product.Details;
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
                ViewBag.Data = db.TBLProduct.Where(x => x.ProductID == ID).ToList();

                return View(db.TBLCategory.ToList());
            }
        }
        public ActionResult Delete(int ID)
        {

            using (EntityContext db = new EntityContext())
            {
                db.TBLProduct.Remove(db.TBLProduct.Find(ID));
                db.SaveChanges();

            }
            return Redirect("/admin/Products");
        }
    }


}