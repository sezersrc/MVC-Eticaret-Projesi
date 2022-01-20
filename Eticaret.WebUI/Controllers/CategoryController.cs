using Eticaret.Business;
using Eticaret.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Eticaret.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CrudeRepositorycs<TBLProduct> Crud = new CrudeRepositorycs<TBLProduct>();

        // GET: Category
        public ActionResult Index(string KategoriAdi ,string Sira)
        {
            using (EntityContext db = new EntityContext())
            {
                ViewBag.Data = db.TBLSettings.ToList();

                var Data = Convert.ToInt32(db.TBLCategory.FirstOrDefault(x => x.CategorySeo == KategoriAdi)
                .CategoryID.ToString());


                ViewBag.Baslik = db.TBLCategory.Where(x => x.CategorySeo == KategoriAdi).FirstOrDefault().Name;

                if (Sira == "FGA")
                {
                    return View(Crud.List(x => x.CategoryID == Data).OrderBy(x => x.DiscountPrice));
                }
                else if (Sira == "FGAZ")
                {
                    return View(Crud.List(x => x.CategoryID == Data).OrderByDescending(x => x.DiscountPrice));
                }
                else if (Sira == "AZ")
                {
                    return View(Crud.List(x => x.CategoryID == Data).OrderBy(x => x.Name));
                }
                else if (Sira == "ZA")
                {
                    return View(Crud.List(x => x.CategoryID == Data).OrderByDescending(x => x.Name));
                }
                else
                {
                    return View(Crud.List(x => x.CategoryID == Data));
                }

            }
           


            //var db = new ConnectionBase();
            // Stack Bölgesinde Tutulsun diye sadece ID Sütununu alıyorum.
            

            
        }
    }
}