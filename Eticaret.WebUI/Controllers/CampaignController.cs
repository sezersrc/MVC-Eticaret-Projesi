using Eticaret.Business;
using Eticaret.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Eticaret.WebUI.Controllers
{
    public class CampaignController : Controller
    {
        private readonly CrudeRepositorycs<TBLProduct> Crud = new CrudeRepositorycs<TBLProduct>();

        // GET: Company
        public ActionResult Index()
        {
            

            using (EntityContext db = new EntityContext())
            {

                ViewBag.Data = db.TBLSettings.ToList();                
                return View(Crud.List(x => x.DiscountPrice != 0));
            }


        }
    }
}