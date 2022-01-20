using Eticaret.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Eticaret.WebUI.Controllers
{
    public class DetailsController : Controller
    {
        // GET: Details
        public ActionResult Index(int ID)
        {

            using (EntityContext db = new EntityContext())
            {
                ViewBag.Data = db.TBLSettings.ToList();
                ViewBag.Data2 = db.TBLProduct.Where(x => x.ProductID == ID).ToList();
                return View(db.TBLCategory.ToList());
                
            }
            
        }

        public ActionResult Deneme()
        {
            using (EntityContext db = new EntityContext())
            {
                ViewBag.Data = db.TBLSettings.ToList();
                
                return View();

            }
        }
    }
}